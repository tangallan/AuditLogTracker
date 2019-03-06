using System;
using AuditLogConsoleApp.Models;
using AuditLogTracking;

namespace AuditLogConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================== TESTING Audit Log Tracker ==================");
            // User name is mock as user context, we can probably use DI to inject user context into our Audit Log
            var userName = "Allan";

            var user = new User()
            {
                FirstName = "Allan",
                LastName = "Tang",
                Email = "tang@gmail.com"
            };
            var userWithTracker = new AuditLogTracker<User>(user, userName);

            userWithTracker.UpdateAndTrack("FirstName", "Allan 2");
            userWithTracker.UpdateAndTrack("LastName", "Tang 2");
            userWithTracker.UpdateAndTrack("Email", "tang@gmail.com");

            userWithTracker.DisplayChanges();

            Console.WriteLine();
            Console.WriteLine($"Validating if the tracker is updating the object properties");
            Console.WriteLine($"FirstName should be 'Allan 2' ===> {user.FirstName.Equals("Allan 2")}");
            Console.WriteLine($"LastName should be 'Tang 2' ===> {user.LastName.Equals("Tang 2")}");
            Console.WriteLine($"Email should be 'Allan 2' ===> {user.Email.Equals("tang.allan03+1@gmail.com")}");

            Console.WriteLine();

            var product = new Product()
            {
                ProductNumber = "p-1000",
                Sku = "sku-100",
                ProductCost = 23.99m,
                Height = 15,
                Length = 15,
                Width = 15,
                Weight = 23
            };
            var productWithTracker = new AuditLogTracker<Product>(product, userName);
            productWithTracker.UpdateAndTrack("Weight", 25);
            productWithTracker.UpdateAndTrack("ProductCost", 29.99m);
            productWithTracker.UpdateAndTrack("ProductCost", 30.99m);
            productWithTracker.UpdateAndTrack("ProductCost", 33.99m);
            productWithTracker.UpdateAndTrack("ProductCost", 35.99m);

            productWithTracker.DisplayChanges();  // console writeline the changes


            Console.WriteLine("================== DONE TESTING Audit Log Tracker ==================");
            Console.ReadLine();
        }
    }
}
