using CinemaBoutique.DAL.EF.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Boutique.Configuration;
using Cinema_Boutique.Mappings;
using CinemaBoutique.BLL.Interfaces;
using CinemaBoutique.BLL.Services;
using CinemaBoutique.Core.Models;
using CinemaBoutique.DAL.EF.Repositories;
using CinemaBoutique.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cinema_Boutique
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
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            services.AddScoped<IRepositoryAsync<Cinema>, CinemasRepository>();
            services.AddScoped<IRepositoryAsync<Actor>, ActorsRepository>();
            services.AddScoped<IRepositoryAsync<FilmStrip>, FilmStripsRepository>();
            services.AddScoped<IRepositoryAsync<FilmSession>, FilmSessionsRepository>();
            services.AddScoped<IRepositoryAsync<Ticket>, TicketsRepository>();

            services.AddScoped<ICinemasService, CinemasService>();
            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IFilmStripsService, FilmStripsService>();
            services.AddScoped<IFilmSessionsService, FilmSessionsService>();
            services.AddScoped<ITicketsService, TicketsService>();

            services.Configure<SecurityOptions>(
                Configuration.GetSection(SecurityOptions.SectionTitle));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider,
            IOptions<SecurityOptions> securityOptions, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            CreateRoles(serviceProvider, securityOptions).Wait();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        private async Task CreateRoles(IServiceProvider serviceProvider, IOptions<SecurityOptions> securityOptions)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "Manager" };
            foreach (var roleName in roles)
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                });


            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            var adminUser = await userManager.FindByEmailAsync(securityOptions.Value.AdminUserEmail);
            if (adminUser != null)
                await userManager.AddToRoleAsync(adminUser, "Admin");
            else
                await CreateUserWithRoleAsync(userManager, securityOptions.Value.AdminUserEmail, securityOptions.Value.Password, "Admin");


            var managerUser = await userManager.FindByEmailAsync(Configuration["Security:ManagerUserEmail"]);
            if (managerUser != null)
                await userManager.AddToRoleAsync(managerUser, "Manager");
            else
                await CreateUserWithRoleAsync(userManager, securityOptions.Value.ManagerUserEmail, securityOptions.Value.Password, "Manager");
        }

        private async Task CreateUserWithRoleAsync(UserManager<User> userManager, string userEmail, string password, string role)
        {
            User user = new User
            {
                UserName = userEmail,
                Email = userEmail,
                EmailConfirmed = true
            };

            IdentityResult result = userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
