using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Console.WriteLine("Starting up ...");
            Configuration = configuration;

            // Initialisation de la base si pas déjà faite
            Console.WriteLine("Initializing database ...");
            var dbcontext = new dal.SampleContextFactory().CreateDbContext(null);
            dbcontext.Database.EnsureCreated();

            Console.WriteLine("Startup done");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
