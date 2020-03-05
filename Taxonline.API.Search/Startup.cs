using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Taxonline.API.Search.Interfaces;
using Taxonline.API.Search.Services;
using Polly;

namespace Taxonline.API.Search
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
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IWorkItesmService, WorkItesmService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddHttpClient("WorkItem", cnf =>
            {
                cnf.BaseAddress = new Uri(Configuration["Services:WorkItem"]);
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)));
            services.AddHttpClient("Activity", cnf =>
            {
                cnf.BaseAddress = new Uri(Configuration["Services:Activity"]);
            });
            services.AddHttpClient("UploadComplaines", cnf =>
            {
                cnf.BaseAddress = new Uri(Configuration["Services:UploadComplaines"]);
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
