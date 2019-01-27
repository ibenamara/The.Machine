using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using The.Machine.Entities;
using The.Machine.Models;
using The.Machine.Services;

namespace The.Machine
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddCors();
            services.AddMvc()
                .AddJsonOptions(o=>
                {
                    if(o.SerializerSettings.ContractResolver != null)
                    {
                        var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                        castedResolver.NamingStrategy = null;
                    }
                }).
                AddMvcOptions(o=>
                {
                    o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                });

            services.AddDbContext<TheMachineContext>(o =>
            {
                o.UseInMemoryDatabase("TheMachine");
            });

            //string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            //services.AddDbContext<TheMachineContext>(o =>
            //{
            //    o.UseSqlServer(connectionString);
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "The Machine Api", Version = "v1" });
            });
            services.AddScoped<IDrinkRepository, DrinkRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseMvc();

            app.UseCors(builder =>
                        builder
                               .AllowAnyHeader()
                        );
            app.UseStatusCodePages();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "The Machine Api");
            });
        }
    }
}
