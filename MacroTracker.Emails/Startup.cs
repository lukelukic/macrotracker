using EventBus;
using EventBus.Events;
using EventBusRabbitMQ;
using MacroTracker.Emails.Extensions;
using MacroTracker.Emails.Interfaces;
using MacroTracker.Emails.Options;
using MacroTracker.Emails.Senders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MacroTracker.Emails
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQEventBus>(
                eb =>
                {
                    var config = Configuration.GetSection("RabbitMQ");
                    return new RabbitMQEventBus(config["host"], config["username"], config["password"]);
                });

            services.Configure<EmailOptions>(options => Configuration.GetSection("Email").Bind(options));
            services.AddTransient<IEmailSender, TestSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var eventBus = app.ApplicationServices.GetService<IEventBus>();
            var emailService = app.ApplicationServices.GetService<IEmailSender>();

            eventBus.ManageSubscriptions(emailService);

            app.Run(async (context) => await context.Response.WriteAsync("Hello World!"));
        }
    }
}