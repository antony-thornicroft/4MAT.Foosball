using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _4MAT.Data;

namespace _4MAT.Foosball
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connectionString = Configuration.GetConnectionString("DataContext");
            services.AddEntityFrameworkSqlite().AddDbContext<DataContext>(opts => opts.UseSqlite(connectionString));

            services.AddScoped<FoosballRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DataContext>())
                {
                    context.Database.Migrate();

                    if (!context.Players.Any())
                    {
                        context.Players.Add(new Player() {Name = "Lawrence"});
                        context.Players.Add(new Player() { Name = "Ant" });
                        context.Players.Add(new Player() { Name = "Paul" });
                        context.Players.Add(new Player() { Name = "Karen" });
                        context.Players.Add(new Player() { Name = "Matt" });
                        context.SaveChanges();
                    }

                    if (!context.Games.Any())
                    {

                        context.Games.Add(new Game()
                        {
                            BluePlayer = context.Players.FirstOrDefault(x => x.Name == "Lawrence"),
                            RedPlayer = context.Players.FirstOrDefault(x => x.Name == "Ant"),
                            KickOff = DateTime.Now.AddDays(-1),
                            RedScore = 10,
                            BlueScore = 2
                        });
                        context.Games.Add(new Game()
                        {
                            BluePlayer = context.Players.FirstOrDefault(x => x.Name == "Lawrence"),
                            RedPlayer = context.Players.FirstOrDefault(x => x.Name == "Paul"),
                            KickOff = DateTime.Now.AddDays(-1),
                            RedScore = 0,
                            BlueScore = 4
                        });
                        context.Games.Add(new Game()
                        {
                            BluePlayer = context.Players.FirstOrDefault(x => x.Name == "Karen"),
                            RedPlayer = context.Players.FirstOrDefault(x => x.Name == "Paul"),
                            KickOff = DateTime.Now.AddDays(-1),
                            RedScore = 6,
                            BlueScore = 6
                        });
                        context.Games.Add(new Game()
                        {
                            BluePlayer = context.Players.FirstOrDefault(x => x.Name == "Matt"),
                            RedPlayer = context.Players.FirstOrDefault(x => x.Name == "Karen"),
                            KickOff = DateTime.Now.AddDays(-1),
                            RedScore = 6,
                            BlueScore = 8
                        });
                        context.Games.Add(new Game()
                        {
                            BluePlayer = context.Players.FirstOrDefault(x => x.Name == "Matt"),
                            RedPlayer = context.Players.FirstOrDefault(x => x.Name == "Lawrence"),
                            KickOff = DateTime.Now.AddDays(-1),
                            RedScore = 1,
                            BlueScore = 4
                        });

                        context.SaveChanges();

                    }

                }
            }

        }
    }
}
