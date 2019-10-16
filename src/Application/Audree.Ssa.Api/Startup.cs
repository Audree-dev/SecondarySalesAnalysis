using System.Text;
using Audree.Ssa.Core.Contracts;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Infrastructure.Data;
using Audree.Ssa.Infrastructure.Repositories.Master;
using Audree.Ssa.Infrastructure.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Infrastructure.Repositories.Admin;
using Swashbuckle.AspNetCore.Swagger;
using Audree.Ssa.Core.Model.Admin;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Audree.Ssa.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("m",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                        //  builder.WithOrigins(Configuration.GetValue<string[]>("CorsConfig:AllowedOrigins"));
                    });
            });

            var sqlConnectionString = Configuration.GetConnectionString("con");
            services.AddDbContext<SSADbContext>(options =>
                options.UseSqlServer(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("Audree.Ssa.Infrastructure"))
                    );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper();
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "SSA API", Version = "V1" });
                });
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // configure DI for application services
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ISSADbContexts, SSADbContext>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IMenuMasterRepository, MenuMasterRepository>();
            services.AddScoped<ISalutationRepository, SalutationRepository>();
            services.AddScoped<IUOMRepository, UOMRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProfilesMastersRepository, ProfilesMasterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReasonForRejectionRepository, ReasonForRejectionRepository>();
            //services.AddScoped<IPasswordpolicyRepository, PasswordpolicyRepository>();
            //services.AddScoped<IChangepasswordRepository, ChangepasswordRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "SSA API Version 1"); });
           

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
             app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseStaticFiles();
            app.UseMvc();
           
        }
    }
}
