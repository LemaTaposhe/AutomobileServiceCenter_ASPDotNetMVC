using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject_Lema.Models
{
    public class AppointMaster
    {
        public int AppointMasterId { get; set; }
        public DateTime AppointDate { get; set; }
        public string CustomerName { get; set; }
        public string Image { get; set; }
        public virtual ICollection<AppointDetail> AppointDetails { get; set; }
    }
}