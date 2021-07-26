using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreDapper.Domain.StoreContext.Handlers;
using StoreDapper.Domain.StoreContext.Repositories;
using StoreDapper.Domain.StoreContext.Services;
using StoreDapper.Infra.StoreContext.DataContexts;
using StoreDapper.Infra.StoreContext.Repositories;
using StoreDapper.Infra.StoreContext.Services;

namespace StoreDapper.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
