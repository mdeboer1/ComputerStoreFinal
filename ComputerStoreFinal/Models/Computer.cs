using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerStoreFinal.Models
{
    public class Computer
    {
        [Required]
        public int ComputerID { get; set; }
        public string ComputerName { get; set; }
        public decimal ComputerPrice { get; set; }
        public string ComputerImg { get; set; }
        
        public int MoboID { get; set; }
        public int CpuID { get; set; }
        public int MemoryID { get; set; }
        public int GpuID { get; set; }
        public int HardDriveID { get; set; }
        public int CaseID { get; set; }
        public int PsuID { get; set; }


    }
}