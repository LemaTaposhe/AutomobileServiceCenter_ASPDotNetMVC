using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject_Lema.Models.View_Models
{
    public class AppointVM
    {
        // Order Details
        public int AppointDetailId { get; set; }
        public int AppointMasterId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //Order Master
        public DateTime AppointDate { get; set; }
        public string CustomerName { get; set; }
        public string Image { get; set; }

        //.........
        public bool Terms { get; set; }
    }
}