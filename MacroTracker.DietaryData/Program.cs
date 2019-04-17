using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MacroTracker.DietaryData
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();

        /*
            U UseStartup metod se prosledjuje ime assemblija iz kog treba da se ucita startup klasa
            Konkretan startup ce se odabrati na osnovu env promenljive ASPNETCORE_ENVIRONMENT iz fajla launchSettings.json
            ili iz environtment varijable os-a, ukoliko nije navedena u launchSettings.json
            Ukoliko je ASPNETCORE_ENVIRONMENT == Production, StartupProduction.cs ce se koristiti kao startup klasa
        */

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var assemblyName = typeof(StartupDevelopment).GetTypeInfo().Assembly.FullName;

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup(assemblyName);
        }
    }
}