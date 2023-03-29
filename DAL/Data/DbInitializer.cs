using DAL.Data;
using MarketApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DBAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var user = new Users[]
            {
            new Users{UserName="Roman",City="Lviv"},
            new Users{UserName="Pavlo",City="Odessa"},
            new Users{UserName="Semen",City="Kuyiv"},
            new Users{UserName="Petro",City="Rivne"},
            };
            foreach (Users s in user)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }
            var products = new List<Products>()
            {
                new Products() { Name = "Tomato Soup", Count = 25, Price = 18.00M },
                new Products() { Name = "Hammer",  Count = 25, Price = 30.00M  },
                new Products() { Name = "Hot-Dog",  Count = 25, Price = 25.00M  },
                new Products() { Name = "Pizza",  Count = 25, Price = 50.00M  }

            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

        }
    }
}
