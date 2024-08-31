using MvcProject_Lema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcProject_Lema.DAL
{
    public class AppointDetailsContest: DbContext
    {
        public AppointDetailsContest() : base("DefaultConnection")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<AppointDetail> AppointDetails { get; set; }
        public DbSet<AppointMaster> AppointMasters { get; set; }

        public System.Data.Entity.DbSet<MvcProject_Lema.Models.Employee> Employees { get; set; }

       // public System.Data.Entity.DbSet<MvcProject_Lema.Models.View_Models.EmployeeVM> EmployeeVMs { get; set; }
    }
}