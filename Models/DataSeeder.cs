using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MvcProject_Lema.Models
{
    public class DataSeeder
    {
        public void seed(ApplicationDbContext context)
        {
            context.Customers.AddOrUpdate(
            c => c.CustomerName,
       new Customer { CustomerName = "Md Rahim", Email = "rahim@example.com", CarNumber = "ABC123", PhoneNumber = "12345678901" },
       new Customer { CustomerName = "Md Korim", Email = "korim@example.com", CarNumber = "XYZ789", PhoneNumber = "98765432109" }
   // Add more customers if needed
   );

            //context.Services.AddOrUpdate(
            //    s => s.Name,
            //    new Service { Name = "Oil Change", Price = 120 },
            //    new Service { Name = "Tire Rotation", Price = 150 }
            //// Add more services if needed
            //);

            context.SaveChanges();

        }
    }
}