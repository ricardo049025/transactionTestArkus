using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;
using Domain.Entities;
using Infraestructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Service.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi
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
            services.AddControllers();
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("dbArkus"));

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceStatusRepository, InvoiceStatusRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceStatusService, InvoiceStatusService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITransactionService, TransactionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>{endpoints.MapControllers();});

            var context = serviceProvider.GetService<ApiContext>();

            //Inialize records
            DataSeeder.Initialize(context);
        }



    }
}
