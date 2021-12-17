using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeventAdminBlazorServer.Areas.Identity;
using IdeventAdminBlazorServer.Data;
using IdeventLibrary.Models;
using Microsoft.EntityFrameworkCore.Design;
using IdeventLibrary;
using IdeventLibrary.Repositories;
using IdeventAdminBlazorServer.Hubs;
using Microsoft.AspNetCore.SignalR;
using IdeventAdminBlazorServer.Common;

namespace IdeventAdminBlazorServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    AppSettings.ConnectionString)); // AppSettings.ConnectionString should be switched when publishing.
            services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            // custom injections
            services.AddSingleton<CompanyRepository>();
            services.AddSingleton<ChipRepository>();
            services.AddSingleton<EventRepository>();
            services.AddSingleton<EventStandRepository>();
            services.AddSingleton<UserRepository>();
            services.AddSingleton<ChipGroupRepository>();
            services.AddSingleton<StandProductRepository>();
            services.AddSingleton<ChipContentRepository>();
            services.AddSingleton<StandFunctionalityRepository>();



            services.AddSignalR();
            services.AddSingleton<IUserIdProvider, NameUserIdProvider>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
           
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapHub<ConnectionHub>("connectionHub");
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
