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
using MobilivaCase.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilivaCase.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MobilivaCase.API", Version = "v1" });
            });

            services.AddDbContext<MobilivaDbContext>(opt =>
            {
                opt.UseMySql(Configuration.GetConnectionString("sqlConnection"));
            });

            services.AddScoped<IOrderDetailRepository, EfOrderDetailRepository>();
            services.AddScoped<IOrderRepository, EfOrderRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IGetProductService, GetProductService>();
            services.AddScoped<ICreateOrderService, CreateOrderService>();
            services.AddMemoryCache();
            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddScoped<IRabbitMQConfiguration, RabbitMQConfiguration>();
            services.AddScoped<IObjectConvertFormat, ObjectConvertFormatManager>();
            services.AddScoped<IMailSender, MailSender>();
            services.AddScoped<ISmtpConfiguration, SmtpConfiguration>();
            services.AddScoped<IPublisherService, PublisherManager>();
            services.AddScoped<IConsumerService, ConsumerManager>();


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MobilivaCase.API v1"));
            }

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
