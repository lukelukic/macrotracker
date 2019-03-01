using EventBus;
using EventBusRabbitMQ;
using Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Application.UseCases;
using MacroTracker.Users.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MacroTracker.Users
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IEventBus, RabbitMQEventBus>(
                eb =>
                {
                    var config = Configuration.GetSection("RabbitMQ");
                    return new RabbitMQEventBus(config["host"], config["username"], config["password"]);
                });
            services.AddMediatR(typeof(RegisterUserUseCase));
            services.AddDbContext<UsersDbContext>(cfg =>
            {
                var connectionString = Configuration.GetSection("SqlConnection").Value;
                cfg.UseSqlServer(connectionString);
            });
            services.AddTransient<ITrainerRepository, EfTrainerRepository>();
            services.AddTransient<IUserRepository, EfUserRepository>();
            services.AddTransient<ITrainingRequestRepository, EfTrainingRequestRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}