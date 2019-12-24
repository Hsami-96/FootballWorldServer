using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballWorldServerSide.Controllers;
using FootballWorldServerSide.Interfaces.Repositories;
using FootballWorldServerSide.Interfaces.Services;
using FootballWorldServerSide.Repositories;
using FootballWorldServerSide.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FootballWorldServerSide
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
            
            services.AddAuthorization();
            services.AddControllers();
            services.AddTransient<IMatchDetailsRepository, MatchDetailsRepository>();
            services.AddTransient<IMatchDetailsService, MatchDetailsService>();
            //services.AddTransient>
            services.AddHttpClient("API Client", client =>
            {
                client.BaseAddress = new Uri("https://api.football-data.org");
                client.DefaultRequestHeaders.Add("X-Auth-Token", "64e7ac48629746dc95fdf8c39a4149df");
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:4200"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

         
        }
    }
}
