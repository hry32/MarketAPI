using DAL.Data;
using MarketApi.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Unity;
using Unity.Injection;
using BAL.Service;
using BAL.Interfaces;
using MarketApi.Domain.Interfaces;
using DAL.Repositories;

namespace MarketAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<IRepository<Users>, UsersRepository>();
            container.RegisterType<IRepository<Products>, ProductsRepository>();
            container.RegisterType<IOrderService, OrderService>();
           container.RegisterType<AppDbContext>(new InjectionConstructor(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options));
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
