using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject_Lema.Models
{
    public class AppointDetail
    {
        public int AppointDetailId { get; set; }
        public int AppointMasterId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public AppointMaster AppointMaster { get; set; }
    }
}