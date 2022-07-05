using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebGame.Database.Model;

namespace WebGame.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //// добавление данных
            //using (WebGameDBContext db = new WebGameDBContext())
            //{
            //    // создаем два объекта User
            //    User user1 = new User { Name = "Tom", Id = Guid.NewGuid() };
            //    User user2 = new User { Name = "Alice", Id = Guid.NewGuid() };

            //    // добавляем их в бд
            //    db.Users.AddRange(user1, user2);
            //    db.SaveChanges();
            //}
            //// получение данных
            //using (WebGameDBContext db = new WebGameDBContext())
            //{
            //    // получаем объекты из бд и выводим на консоль
            //    var users = db.Users.ToList();
            //    Console.WriteLine("Users list:");
            //    foreach (User u in users)
            //    {
            //        Console.WriteLine($"{u.Id}.{u.Name} - {u.Id}");
            //    }
            //}
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
