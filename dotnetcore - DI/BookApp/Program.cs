using BookApp.Dal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookApp
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

            Console.ReadKey();
        }

 
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            //add services
            serviceCollection.AddSingleton<Dal.IBook>(p => new Dal.BookJson(new Bll.Book()));
            //add app
            serviceCollection.AddTransient<App>();
        }

      
    }
}
