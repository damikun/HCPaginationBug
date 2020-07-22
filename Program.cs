using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Aplication.Interfaces;
using Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HC_Pagination_Bug
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

             var host = CreateHostBuilder(args).Build();


             using (var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope()) {

                IAppDbContext _context = scope.ServiceProvider.GetRequiredService<IAppDbContext>();

                var result = await _context.Users.AsNoTracking().Where(e => e.Name == "user1").FirstOrDefaultAsync();

                if (result == null) {
                    _context.Users.Add(new User() { Name = "user1"});
                }

                 result = await _context.Users.AsNoTracking().Where(e => e.Name == "user2").FirstOrDefaultAsync();

                if (result == null) {
                    _context.Users.Add(new User() { Name = "user2"});
                }

                 result = await _context.Users.AsNoTracking().Where(e => e.Name == "user3").FirstOrDefaultAsync();

                if (result == null) {
                    _context.Users.Add(new User() { Name = "user3"});
                }

                 result = await _context.Users.AsNoTracking().Where(e => e.Name == "user4").FirstOrDefaultAsync();

                if (result == null) {
                    _context.Users.Add(new User() { Name = "user4"});
                }

                await _context.SaveChangesAsync(new CancellationToken());

             }
         
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
