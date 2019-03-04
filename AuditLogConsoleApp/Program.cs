using System;
using AuditLogConsoleApp.Models;

namespace AuditLogConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================== TESTING Audit Log Tracker ==================");
            // User name is mock as user context, we can probably use DI to inject user context into our Audit Log
            var userName = "Allan";


            var user = new User(userName)
            {
                FirstName = "Allan"
            };
            user.LastName = "Tang";
            user.Email = "tang.allan03@gmail.com";
            user.FirstName = "Allan 2";
            user.LastName = "Tang 2";

            user.DisplayChanges(); // console writeline the changes

            Console.WriteLine();


            var product = new Product(userName)
            {
                ProductNumber = "p-1000",
                Sku = "sku-100",
                ProductCost = 23.99m,
                Height = 15,
                Length = 15,
                Width = 15,
                Weight = 23
            };
            product.Weight = 25;
            product.ProductCost = 29.99m;
            product.ProductCost = 30.99m;
            product.ProductCost = 33.99m;
            product.ProductCost = 35.99m;
            
            product.DisplayChanges();  // console writeline the changes
            
           
            Console.WriteLine("================== DONE TESTING Audit Log Tracker ==================");
            Console.ReadLine();
        }
    }
}
