using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pioneer.Pagination;
using WebEvento.Cashing;
using WebEvento.Data;
using WebEvento.Data.Services;
using WebEvento.Data.Services.Email;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;
using WebExhibitionoo_DomainClasses.Services;

namespace WebEvento
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



            // Add an in-memory cache service provider
            services.AddMemoryCache();
            services.AddSingleton<CacheManager>();


            //for Pageination
            services.AddTransient<IPaginatedMetaService, PaginatedMetaService>();
            //for current user
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<DbContext, WebDbContext>();
            services.AddTransient<Seeder>();
            services.AddScoped<INotPublishedServices, NotPublishedServices>();
            services.AddScoped<ITranctionServices, TranctionServices>();
            services.AddScoped<IColorService, ColorsServices>();
            services.AddScoped<IReportServices, ReportServices>();
            services.AddScoped<IAddresServices, AddressService>();
            services.AddScoped<WebEventoo_DomainClasses.Services.IExhibitionServices, CermoneyServic>();
            services.AddScoped<IEductionservices, EductionService>();
            services.AddScoped<IEventServices, EventService>();
            services.AddScoped<WebExhibitionoo_DomainClasses.Services.IExhibitionServices, ExhibitionService>();
            services.AddScoped<IPlaceServices, PlaceService>();
            services.AddScoped<ICommentService, CommentServices>();
            services.AddScoped<IInformationService, InformationServices>();

            services.AddDbContext<Data.WebDbContext>(option =>
    option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<Users, IdentityRole>(   )
            //    .AddEntityFrameworkStores<WebDbContext>()
            //    .AddDefaultTokenProviders();
            //services.AddDefaultIdentity<Users>(
            //    option => option.Password.RequireDigit = false




            //    )
            //    .AddRoles<IdentityRole>(

            //    )
            //    .AddEntityFrameworkStores<WebDbContext>();

            //services.AddIdentity<Users, IdentityRole>(options =>
            //{
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 6;
            //    // options.Password.RequiredUniqueChars = 1;

            //    // Lockout settings.
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.MaxFailedAccessAttempts = 5;
            //    options.Lockout.AllowedForNewUsers = true;

            //    // User settings.
            //    //options.User.AllowedUserNameCharacters =
            //    //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    options.User.RequireUniqueEmail = false;

            //}).AddEntityFrameworkStores<WebDbContext>();  
            services.AddIdentity<Users, IdentityRole>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                // options.Password.RequiredUniqueChars = 1;
             //   options.Stores.ProtectPersonalData = true;
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                //options.User.AllowedUserNameCharacters =
                //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            })
      .AddEntityFrameworkStores<WebDbContext>();






            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //    options.LoginPath = "/Account/Login";
            //    options.AccessDeniedPath = "/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});
         services.AddTransient<IEmailSender, EmailSender>();


            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
        .AddCookie();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
          


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
      
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                  //  scope.ServiceProvider.GetService<Seeder>().Seed().Wait();

                };
            }
           app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

               
            }
          
            else
            {
           //  app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();
            app.UseCookiePolicy();
            using (var scope = app.ApplicationServices.CreateScope())
            {
              //  scope.ServiceProvider.GetService<Seeder>().Seed().Wait();

            }
           app.UseAuthentication();
            app = app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
