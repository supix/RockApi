using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using Logging;
using Microsoft.Extensions.Hosting;
using DomainModel.Classes;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Persistence.SQLServer.data;
using System;

namespace RockApi
{
    public class Startup
    {
        private Container container = new SimpleInjector.Container();

        public Startup(IConfiguration configuration)
        {
            // Set to false. This will be the default in v5.x and going forward.
            container.Options.ResolveUnregisteredConcreteTypes = false;

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();


            // Configure ConnectionString DB by Appsetting

            //IServiceCollection serviceCollection = services.AddDbContext<CIRDbContext>(
            //    o => o.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            //IServiceCollection serviceCollection = services.AddDbContext<CIRDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("SqlServer"),
            //        sqlServerOptionsAction: sqlOptions =>
            //        {
            //            sqlOptions.EnableRetryOnFailure(
            //            maxRetryCount: 5,
            //            maxRetryDelay: TimeSpan.FromSeconds(30),
            //            errorNumbersToAdd: null);
            //        }
            //    );
            //});

            //ServiceCollection serviceCollection = (ServiceCollection)services.AddDbContext<CIRDbContext>();

            IServiceCollection serviceCollection = services.AddDbContextPool<CIRDbContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("SqlServer")),30); // poolSize aggiunto = 30 , default = 1024

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

            services.AddControllers();

            IntegrateSimpleInjector(services);
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            // Sets up the basic configuration that for integrating Simple Injector with ASP.NET
            // Core by setting the DefaultScopedLifestyle, and setting up auto cross wiring.
            services.AddSimpleInjector(container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope and allows
                // request-scoped framework services to be resolved.
                options.AddAspNetCore()

                    // Ensure activation of a specific framework type to be created by Simple
                    // Injector instead of the built-in configuration system. All calls are
                    // optional. You can enable what you need. For instance, PageModels and
                    // TagHelpers are not needed when you build a Web API.
                    .AddControllerActivation()
                    .AddViewComponentActivation();

                // Optionally, allow application components to depend on the non-generic ILogger
                // (Microsoft.Extensions.Logging) or IStringLocalizer
                // (Microsoft.Extensions.Localization) abstractions.
                options.AddLogging();
            });

            InitializeContainer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // see https://simpleinjector.readthedocs.io/en/latest/aspnetintegration.html

            // UseSimpleInjector() finalizes the integration process.
            app.UseSimpleInjector(container);

            /***********************************************/
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            /***********************************************/

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials               

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            LogConfigurator.Configure();

            container.Verify();
        }

        private void InitializeContainer()
        {
            CompositionRoot.RootBindings.Bind(container);
        }
    }
}