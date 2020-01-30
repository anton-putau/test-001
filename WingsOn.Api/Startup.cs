using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WingsOn.Api.Infrastructure;
using WingsOn.Api.Contracts.Converters;
using WingsOn.Api.Services;
using WingsOn.Dal;
using Newtonsoft.Json.Serialization;

namespace WingsOn.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
              .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<PersonRepository>();
            services.AddSingleton<FlightRepository>();
            services.AddSingleton<BookingRepository>();
            services.AddSingleton<PersonService>();
            services.AddSingleton<FlightService>();
            services.AddSingleton<BookingService>();
            services.AddSingleton<SearchService>();
            services.AddSingleton<IEntityConverter<Domain.Person, Contracts.Person>, PersonConverter>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandler>();

            app.UseMvc();
        }
    }
}
