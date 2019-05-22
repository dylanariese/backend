using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffee.Api.Authorization;
using Coffee.Api.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Core;
using Microsoft.EntityFrameworkCore;
using Coffee.Data;
using Coffee.Core.Users;
using Coffee.Core;

namespace Coffee.Api
{
    public class Startup
    {
        private readonly Logger logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.Configure<IISOptions>(options => options.AutomaticAuthentication = true);

            services.AddTransient<IAuthorizationHandler, AdminEntryHandler>();
            services.AddAuthorization(options => options.AddPolicy("AdminAuthorization", policy => policy.Requirements.Add(new AdminEntryRequirement())));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddControllersAsServices();

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            var connectionString = Configuration.GetConnectionString("CoffeeContext");
            services.AddDbContext<CoffeeContext>
                (options => options.UseSqlServer(connectionString));

            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(logger));
            services.AddCors();

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IEventsService, EventsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            var allowed = Configuration.GetSection("allowCorsOrigins").Get<string[]>();
            app.UseCors(builder => builder.WithOrigins(allowed).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseMvc();
        }
    }
}
