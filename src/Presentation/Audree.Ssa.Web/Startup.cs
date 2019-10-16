using Audree.Ssa.Infrastructure.Data;
using Audree.Ssa.Infrastructure.Repositories.Master;
using Audree.Ssa.Infrastructure.UnitOfWork;
using Audree.Ssa.Core.Contracts;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Infrastructure.Repositories.Admin;
using AutoMapper;
using Audree.Ssa.Core.Mapper;
using Microsoft.AspNetCore.Identity;

namespace Audree.Ssa.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddMvc();
            // Start of the Auto Mapper 
            var Config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new MapperProfile());
            });
            var mapper = Config.CreateMapper();
            services.AddSingleton(mapper);
            //End of the Auto Mapper

            //connection string configuration
            var sqlConnectionString = Configuration.GetConnectionString("con");
            services.AddDbContext<SSADbContext>(options =>
                options.UseSqlServer(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("Audree.Ssa.Infrastructure")
                    )
                    );
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //        .AddEntityFrameworkStores<SSADbContext>()
            //        .AddDefaultTokenProviders();

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<ISalutationRepository, SalutationRepository>();
            services.AddScoped<IUOMRepository, UOMRepository>();
            //services.AddScoped<ISSADbContext, SSADbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
 			services.AddScoped<IProfilesMastersRepository, ProfilesMasterRepository>();
            services.AddScoped<IPasswordpolicyRepository, PasswordpolicyRepository>();
            services.AddScoped<IChangepasswordRepository, ChangepasswordRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               //app.UseExceptionHandler("/Error/LogError");

            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseStatusCodePages(); // Added
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
