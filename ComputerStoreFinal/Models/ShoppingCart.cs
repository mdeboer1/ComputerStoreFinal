using ComputerStoreFinal.DataContexts;
using ComputerStoreFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerStoreFinal.Models
{
    public partial class ShoppingCart
    {
        private ComputerStoreDb ComputerStoreDb = new ComputerStoreDb();
        string ShoppingCartID { get; set; }
        public const string CartSessionKey = "CartID";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartID = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Part part)
        {
                // Get the matching cart and album instances
                var cartItem = ComputerStoreDb.Carts.SingleOrDefault(
                    c => c.CartID == ShoppingCartID
                    && c.PartID == part.PartID);

                if (cartItem == null)
                {
                    // Create a new cart item if no cart item exists
                    cartItem = new Cart
                    {
                        PartID = part.PartID,
                        CartID = ShoppingCartID,
                        Count = 1,
                        DateCreated = DateTime.Now
                    };
                    ComputerStoreDb.Carts.Add(cartItem);
                }
                else
                {
                    // If the item does exist in the cart, 
                    // then add one to the quantity
                    cartItem.Count++;
                }
            // Save changes
            ComputerStoreDb.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = ComputerStoreDb.Carts.Single(
                cart => cart.CartID == ShoppingCartID
                && cart.RecordID == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    ComputerStoreDb.Carts.Remove(cartItem);
                }
                // Save changes
                ComputerStoreDb.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = ComputerStoreDb.Carts.Where(
                cart => cart.CartID == ShoppingCartID);

            foreach (var cartItem in cartItems)
            {
                ComputerStoreDb.Carts.Remove(cartItem);
            }
            // Save changes
            ComputerStoreDb.SaveChanges();
        }
        public List<Cart> GetCartItems()
        {
            return ComputerStoreDb.Carts.Where(
                cart => cart.CartID == ShoppingCartID).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in ComputerStoreDb.Carts
                          where cartItems.CartID == ShoppingCartID
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in ComputerStoreDb.Carts
                              where cartItems.CartID == ShoppingCartID
                              select (int?)cartItems.Count *
                              cartItems.Part.PartPrice).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderpart = new OrderPart
                {
                    PartID = item.PartID,
                    OrderID = order.OrderID,
                    PartPrice = item.Part.PartPrice,
                    Quantity = item.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Part.PartPrice);

                ComputerStoreDb.OrderParts.Add(orderpart);

            }
            // Set the order's total to the orderTotal count
            order.Subtotal = orderTotal;
            // Free shipping for now
            decimal shipping = 0;
            order.ShippingTotal = orderTotal + shipping;
            // Calculate tax
            decimal salesTax = .051m * orderTotal;
            order.SalesTax = salesTax;
            order.Total = order.ShippingTotal + salesTax;

            ComputerStoreDb.Orders.Add(order);

            // Save the order
            ComputerStoreDb.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderID;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = ComputerStoreDb.Carts.Where(
                c => c.CartID == ShoppingCartID);

            foreach (Cart item in shoppingCart)
            {
                item.CartID = userName;
            }
            ComputerStoreDb.SaveChanges();
        }
    }
}