using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AssessmentDb.Data;
using AssessmentDb.Models;

namespace AssessmentDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer("Server=MORISS-PC;Database=AssessmentDb User Id=sa; Password=4799;Trusted_Connection=True; Encrypt=false;"))
                .BuildServiceProvider();

            using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.Database.EnsureCreated();

                var user1 = new User { Username = "JohnDoe" };
                var user2 = new User { Username = "JaneSmith" };

                var product1 = new Product { Name = "Product A", Price = 10.99m };
                var product2 = new Product { Name = "Product B", Price = 20.49m };

                var order1 = new Order { OrderDate = DateTime.Now, User = user1 };
                var order2 = new Order { OrderDate = DateTime.Now, User = user2 };

                var shipment1 = new Shipment { ShipmentDate = DateTime.Now, Order = order1 };
                var payment1 = new Payment { Amount = 100.00m, Order = order1 };

                var cart1 = new Cart { User = user1 };
                // cart1.Products.Add(product1);

                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Products.Add(product1);
                context.Products.Add(product2);
                context.Orders.Add(order1);
                context.Orders.Add(order2);
                context.Shipments.Add(shipment1);
                context.Payments.Add(payment1);
                context.Carts.Add(cart1);

                context.SaveChanges();

                var usersWithOrders = context.Users
                    .Include(u => u.Orders)
                        .ThenInclude(o => o.Products)
                    .Include(u => u.Cart)
                        .ThenInclude(c => c.Products)
                    .ToList();

                foreach (var user in usersWithOrders)
                {
                    Console.WriteLine($"User: {user.Username}");
                    foreach (var order in user.Orders)
                    {
                        Console.WriteLine($"- Order Date: {order.OrderDate}");
                        foreach (var product in order.Products)
                        {
                            Console.WriteLine($"  - Product: {product.Name} - Price: {product.Price:C}");
                        }
                    }

                    Console.WriteLine("Cart:");
                    if (user.Cart != null && user.Cart.Products != null)
                    {
                        foreach (var product in user.Cart.Products)
                        {
                            Console.WriteLine($"- Product in Cart: {product.Name} - Price: {product.Price:C}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cart is empty.");
                    }
                }
            }
        }
    }
}
