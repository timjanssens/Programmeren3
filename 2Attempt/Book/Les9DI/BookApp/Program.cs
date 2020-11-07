using System;
using System.ComponentModel.Design;
using BookApp.Dal;
using Microsoft.Extensions.DependencyInjection;

namespace BookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
           // var service = serviceProvider.GetService<IBook>();

            serviceProvider.GetService<App>().TryOut();
            
;

            Console.ReadKey();
        }

   
  

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<BookApp.Dal.IBook>
                (p => new BookApp.Dal.BookJson(new BookApp.Bll.Book()));
            serviceCollection.AddTransient<App>();
        }





        public static void CreateCSV()
        {
            Console.WriteLine("".PadLeft(60, '*'));
            Console.WriteLine("\n\n\nDe BookApp CSV\n\n\n");
            Console.WriteLine("".PadLeft(60, '*'));

            Bll.Book book = new Bll.Book();
            Dal.BookXml bookXml = new Dal.BookXml(book);
            bookXml.Book = book;
            bookXml.ReadAll();
            Console.WriteLine(bookXml.Message);

            Dal.BookCsv bookCsv = new Dal.BookCsv(book);
            bookCsv.ConnectionString = @"Data/Book2";
            bookCsv.Create('|');
            Console.WriteLine(bookCsv.Message);
        }





    }
}
