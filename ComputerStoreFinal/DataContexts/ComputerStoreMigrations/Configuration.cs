namespace ComputerStoreFinal.DataContexts.ComputerStoreMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ComputerStoreFinal.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ComputerStoreFinal.DataContexts.ComputerStoreDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\ComputerStoreMigrations";
        }

        protected override void Seed(ComputerStoreFinal.DataContexts.ComputerStoreDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var Parts = new List<Part>
            {
                new Part{ PartID = 1, ModelNumber = "F3-12800CL9D-8GBRL",
                    PartName = "G.SKILL Ripjaws Series 8GB (2 x 4GB) 240-Pin DDR3 SDRAM DDR3 1600 (PC3 12800) Desktop Memory",
                    PartDescription = "This Ripjaws Series memory kit is designed specifically to complement the dual channel based chipsets, and eliminates data bottleneck by doubling your memory bandwidth. Optimized for speed, low latency and high stability, Ripjaws Series memory is the perfect solution to overall more responsive system. Heat management is always important for any PC builder and enthusiast. G.SKILL understands this concern, which is why each Ripjaws Series DIMM comes with a stylish comb-like design heat-spreader, which dissipates heat by exposing it to cool air over a greater surface area and will look great in any case. These DIMMs also operate at a cool 1.5V for better internal temperature and compatibility."
                    , PartPrice = 79.99m, PartImg = "", CategoryID = 3},
                new Part{ PartID = 2, ModelNumber = "F3-1866C9D-16GSR", 
                    PartName = "G.SKILL Sniper Series 16GB (2 x 8GB) 240-Pin DDR3 SDRAM DDR3 1866 (PC3 14900)",
                    PartDescription = "The G.SKILL Sniper Gaming Series memory kit is designed to complement dual-channel-based chipsets, and eliminates data bottlenecks by doubling your memory bandwidth. Optimized for speed, low latency, and high stability, the Sniper Gaming Series memory is the perfect solution to build a more responsive system."
                    , PartPrice = 164.99m, PartImg = "", CategoryID = 3},
                new Part{ PartID = 3, ModelNumber = "F3-1866C8Q-32GTX", PartName = 
                    "G.SKILL Trident X Series 32GB (4 x 8GB) 240-Pin DDR3 SDRAM DDR3 1866 (PC3 14900)",
                    PartDescription = "Breaking the highest DDR3 speed world record at a staggering 4404MHz in 2013, G.SKILL TridentX series is known as the world's most powerful and fastest DDR3 memory available on the market. Named after the powerful weapon of Poseidon, Greek God of the Seas, G.SKILL TridentX is imbued with extreme overclocking capabilities waiting to be unleashed in your system. "
                    , PartPrice = 349.99m, PartImg = "", CategoryID = 3},
                new Part{ PartID = 4, ModelNumber = "R9280X-DC2T-3GD5", PartName = "ASUS Radeon R9 280X 3GB",
                    PartDescription = "DirectCU II achieves 20% lower temps with direct-contact copper heatpipes, plus 3X quieter and 6X more powerful twin 100mm fan operation. Exclusive CoolTech Fan drives wider airflow to keep critical components cool. Top-selected 1070MHz cores run 70MHz higher than reference for smoother gameplay. DIGI+ VRM with 12-phase Super Alloy Power delivers precise digital power for superior efficiency, reliability, and performance. GPU Tweak helps you modify clock speeds, voltages, fan performance and more, all via an intuitive interface."
                    , PartPrice = 259.99m, PartImg = "", CategoryID = 4},
                new Part{ PartID = 5, ModelNumber = "STRIX-GTX970-DC2OC-4GD5", PartName = "ASUS GeForce GTX 970 4GB", 
                    PartDescription = "1253MHz Boost Clock for better performance and an outstanding gaming experience. DirectCU II with 0dB Fan Technology lets you enjoy light games in complete silence, and hardcore gaming 30% cooler with 3X quieter performance! DIGI+ VRM with 6-Phase Super Alloy Power delivers precise digital power for superior efficiency, reliability, and performance. GPU Tweak helps you modify clock speeds, voltages, fan performance and more, all via an intuitive interface. GPU Tweak Streaming share on-screen action in real time – so others can watch live as games are played."
                    , PartPrice = 349.99m, PartImg = "", CategoryID = 4},
                new Part{ PartID = 6, ModelNumber = "STRIX-GTX980-DC2OC-4GD5", PartName = "ASUS GeForce GTX 980 4G",
                    PartDescription = "1279MHz Boost Clock for better performance and an outstanding gaming experience. DirectCU II with 0dB Fan Technology lets you enjoy light games in complete silence, and hardcore gaming 30% cooler with 3X-quieter performance! DIGI+ VRM with 10-Phase Super Alloy Power delivers precise digital power for superior efficiency, reliability, and performance. GPU Tweak helps you modify clock speeds, voltages, fan performance and more, all via an intuitive interface. GPU Tweak Streaming share on-screen action in real time – so others can watch live as games are played."
                    , PartPrice = 579.99m, PartImg = "", CategoryID = 4},
                new Part{ PartID = 7, ModelNumber = "ARESIII-8GD5", PartName = "ASUS Radeon R9 295X2 8GB",
                    PartDescription = "Dual R9 290X Factory-Overclocked to 1030MHz- Delivering a 15% faster performance than GTX Titan Z Made for Water-Cooled Rig Featuring Custom-Designed EK Water Block– Running at 25% cooler than reference R9 295X2 DIGI+ VRM with Black Metallic Capacitors and 16-Phase Super Alloy Power:30%-Less power noise and 5X-greater durability GPU Tweak:Modify clock speeds, voltages, fan performance and more, all via an intuitive interface."
                    , PartPrice = 1499, PartImg = "", CategoryID = 4},
                new Part{ PartID = 8, ModelNumber = "CA-PH410-G1", PartName = "NZXT Phantom 410 Series",
                    PartDescription = "NZXT introduces the descendant of the revolutionary Phantom, the Phantom 410. The beautiful and sleek Phantom design sets the trend for all-white chassis - ideal for optimal expansion and cooling. In comparison to its predecessor, the Phantom 410 delivers more value for your dollar and possesses an acrylic window which allows gamers to admire the power of their rig. The Phantom 410 features innovative right-mounted HDD rails, a solution for easy hard drive replacement. This mid-tower comes equipped with a dual radiator water cooling solution with a clearance of 30mm, an interior pivot 120mm/140mm fan slot, the capability of installing up to eight fans, and a single 30W fan control. The Phantom comes with two internal USB 3.0 headers that directly connect to the motherboard. Be the envy of all PC gamers - the Phantom 410 is bringing sexy back. "
                    , PartPrice = 99.99m, PartImg = "", CategoryID = 6},
                new Part{ PartID = 9, ModelNumber = "S210-001", PartName = "NZXT Source 210",
                    PartDescription = "Gamers spend approximately $60 per game and buy X number of video game titles per year. You know what it’s like...it adds up very quickly. Sometimes gamers are starving college students, sometimes gamers have girlfriends; the green keeps flying away. NZXT’s Source 210 is here to provide the basic chassis to house your rig. It’s modest and contains the essentials for performance. It’s the chassis you can afford. The Source Series is NZXT’s chassis line designed to be a starting block for first time builders or a stepping stone for those who want to upgrade their rig later on. Each chassis faithfully serves their purpose as an affordable, memorable part of your system building experience; it may just be a keeper."
                    , PartPrice = 44.99m, PartImg = "", CategoryID = 6},
                new Part{ PartID = 10, ModelNumber = "921RB-001-BL", PartName = "NZXT Guardian 921",
                    PartDescription = "NZXT celebrates the rebirth of the Guardian 921 with the renewed Guardian 921 RB. Expanded upon its predecessor, Guardian 921 RB reflects the gamer design, structural integrity, and temperature monitoring system of the original while displaying a wide range of new features to complete the system builder's dream budget case. New features include a bottom-oriented power supply mount, CPU heatsink cutout, and an extra 140mm fan slot. Game beyond your limits with the Guardian 921 RB. "
                    , PartPrice = 69.99m, PartImg = "", CategoryID = 6},
                new Part{ PartID = 11, ModelNumber = "M12II 520 Bronze", PartName = "SeaSonic M12II 520 Bronze 520W",
                    PartDescription = "SeaSonic Electronics launches the M12II \"Bronze\" Series, the new and upgraded version of the M12II Series in response to the growing demand and anticipation for more energy-efficient products. The M12II Bronze Series inherits the same output and wattage options as well as the superb quality and ultimate silence from the M12II Series. The M12II Bronze Series, available in 520W and 620W, offers buyers with a mid-range power output solution with cable management to meet their exact system needs - cable management is now made esier than ever."
                    , PartPrice = 69.99m, PartImg = "", CategoryID = 7},
                new Part{ PartID = 12, ModelNumber = "SS-1250XM2", PartName = "SeaSonic X-1250 1250W", 
                    PartDescription = "Common to all X-Series power supplies, the new X-1050 and X-1250 feature the unique integrated DC connector panel with onboard Voltage Regulator Module (VRM) that enables not only near perfect D-to-D conversion with reduction of current loss / impedance and increase of efficiency but also a fully modular DC cabling that enables maximum flexibility of integration and forward compatibility."
                    , PartPrice = 239.99m, PartImg = "", CategoryID = 7},
                new Part{ PartID = 13, ModelNumber = "SS-850KM3 Active PFC F3", PartName = "SeaSonic X Series X-850 850W",
                    PartDescription = "The Sea Sonic X850 power supply provides a maximum power of 850W to deliver safe, reliable output for high-end computer systems. A strong +12V single rail ensures the maximum provision of 12V power to energy-hungry components such as CPU and VGA card, minimizing the likelihood of overload shut down. "
                    , PartPrice = 169.99m, PartImg = "", CategoryID = 7},
                new Part{ PartID = 14, ModelNumber = "Z97-A", PartName = "ASUS Z97-A", 
                    PartDescription = "M.2 & SATA Express - Speed up your system with lightning-fast 10Gbps transfer speed Crystal Sound 2 and Intel Gigabit Ethernet — A game-winning combo! ASUS HomeCloud - Access your PC remotely and stream multimedia content anywhere, anytime Proven Quality – 5X Protection. 1000+ compatible devices. 7000+ validation hours."
                    , PartPrice = 149.99m, PartImg = "", CategoryID = 1},
                new Part{ PartID = 15, ModelNumber = "Z97-P", PartName = "ASUS Z97-P",
                    PartDescription = "This motherboard supports Intel® 4th , New 4th and 5th Generation Core™ i7/i5/i3/Pentium®/Celeron® processors in the LGA1150 package, with iGPU, memory and PCI Express controllers integrated to support onboard graphics output with dedicated chipsets, 2-channel (4 DIMM) DDR3 memory and 16 PCI Express 3.0/2.0 lanes. This provides great graphics performance."
                    , PartPrice = 119.99m, PartImg = "", CategoryID = 1},
                new Part{ PartID = 16, ModelNumber = "MAXIMUS VII HERO", PartName = "ASUS MAXIMUS VII HERO",
                    PartDescription = "The Hero supports all current Intel 4th Generation (Haswell, Haswell-refresh) and future 5th Generation (Broadwell) CPUs on LGA1150. The Extreme Engine DIGI+ III hardware includes 8 + 2-phase power, NexFET™ Power Block MOSFET, 60A Ferrite Chokes, and 10K Black Metallic Capacitors to make overclocking a cinch. On the memory front there's support for four DDR3 DIMMS up to and beyond 3,200MHz, depending on what kit you choose to pair it with."
                    , PartPrice = 219.99m, PartImg = "", CategoryID = 1},
                new Part{ PartID = 17, ModelNumber = "BX80646I74790K", PartName = "Intel Core i7-4790K", 
                    PartDescription = "Clock Speed: 4GHz, Max Clock Speed: 4.4GHz, Cache: 8MB, Cores/Threads: 4 Cores/8Threads, Processor Graphics: Intel® HD Graphics 4600."
                    , PartPrice = 349.99m, PartImg = "", CategoryID = 2},
                new Part{ PartID = 18, ModelNumber = "BX80646I54690K", PartName = "Intel Core i5-4690K",
                    PartDescription = "Clock Speed: 3.4GHz, Max Clock Speed: 3.9GHz, Cache: 6MB, Cores/Threads: 4 Cores/4Threads, Processor Graphics: Intel® HD Graphics 4600."
                    , PartPrice = 219.99m, PartImg = "", CategoryID = 2},
                new Part { PartID =20, ModelNumber = "MZ-75E500B/AM", PartName="SAMSUNG 850 EVO-Series 500GB",
                PartDescription="Upgrade virtually every aspect of your computer’s performance with Samsung’s new 850 EVO, designed with state-of-the-art SSD advancements, including 3D V-NAND technology. As the next generation beyond the bestselling 840 EVO, you’ll get the 850 EVO’s new 3-dimensional chip design that enables superior performance, greater reliability and superior energy efficiency - so you can work and play faster and longer than ever before.",
                PartPrice=249.99m, PartImg="",CategoryID=5},
                new Part {PartID= 21, ModelNumber="MZ-75E1T0B/AM", PartName="SAMSUNG 850 EVO-Series 1TB",
                PartDescription="Upgrade virtually every aspect of your computer’s performance with Samsung’s new 850 EVO, designed with state-of-the-art SSD advancements, including 3D V-NAND technology. As the next generation beyond the bestselling 840 EVO, you’ll get the 850 EVO’s new 3-dimensional chip design that enables superior performance, greater reliability and superior energy efficiency - so you can work and play faster and longer than ever before.",
                PartPrice=469.99m,PartImg="",CategoryID=5}
            };
            var Categories = new List<Category>{
                new Category{ CategoryID = 1, Name = "Motherboard"},
                new Category{ CategoryID = 2, Name = "CPU"},
                new Category{ CategoryID = 3, Name = "Memory"},
                new Category{ CategoryID = 4, Name = "GPU"},
                new Category{ CategoryID = 5, Name = "Hard Drive"},
                new Category{ CategoryID = 6, Name = "Case"},
                new Category{ CategoryID = 7, Name = "Power Supply"}
            };
            context.Parts.AddOrUpdate<Part>(Parts.ToArray<Part>());
            context.Categories.AddOrUpdate<Category>(Categories.ToArray<Category>());
            context.SaveChanges();
        }
    }
}
