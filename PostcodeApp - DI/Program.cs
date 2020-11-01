using Microsoft.Extensions.DependencyInjection;
using PostcodeApp.Dal;
using System;

namespace PostcodeApp
{
    class Program
    {
        static void Main(string[] args)
        {


            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<App>().TryOut();
            Console.ReadLine();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            serviceCollection.AddSingleton<Dal.IPostcode>(p => new Dal.PostcodeJson(new Bll.Postcode()));
            // add app
            serviceCollection.AddTransient<App>();
        }



    }
}