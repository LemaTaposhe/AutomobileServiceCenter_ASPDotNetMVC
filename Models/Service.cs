using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject_Lema.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int CategoryId { get; set; }
    }
}