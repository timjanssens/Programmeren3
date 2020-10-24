using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace DotNetCore.Learning
{
    class BookSerializing
    {
        public static List<Book> DeserializeFromXml()
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Books";
            // xRoot.Namespace = "http://www.cpandl.com";
            xRoot.IsNullable = true;
            XmlSerializer serializer = new XmlSerializer(typeof(Book[]), xRoot);
            Book book = new Book();
            StreamReader file = new StreamReader(@"Data/Book.xml");
            Book[] books = (Book[])serializer.Deserialize(file);
            file.Close();
            // array converteren naar List
            return new List<Book>(books);
        }

        public static string SerializeListToCsv(List<Book> list, string fileName, string separator)
        {
            string message;
            try
            {
                TextWriter writer = new StreamWriter(fileName);
                foreach (Book item in list)
                {
                    // One of the most versatile and useful additions to the C# language in version 6
                    // is the null conditional operator ?.           
                    writer.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}",
                        item?.Title,
                        separator,
                        item?.Year,
                        separator,
                        item?.City,
                        separator,
                        item?.Publisher,
                        separator,
                        item?.Author,
                        separator,
                        item?.Edition,
                        separator,
                        item?.Translator,
                        separator,
                        item?.Comment);
                }
                writer.Close();
                message = $"Het bestand met de naam {fileName} is gemaakt!";
            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                message = $"Kan het bestand met de naam {fileName} niet maken.\nFoutmelding {e.Message}.";
            }
            return message;
        }

        public static string ReadBooksFromCSVFile()
        {
            Helpers.Tekstbestand bestand = new Helpers.Tekstbestand();
            bestand.FileName = @"Data/Book.csv";
            bestand.Lees();
            return bestand.Text;
        }

        public static Book BookCsvToObject(string line, string separator)
        {
            Book book = new Book();
            string[] values = line.Split(separator);
            book.Title = values[0];
            book.Year = values[1];
            book.City = values[2];
            book.Publisher = values[3];
            book.Author = values[4];
            book.Edition = values[5];
            book.Translator = values[6];
            book.Comment = values[7];
            return book;
        }

        public static List<Book> DeserializeCsvToList(string separator)
        {
            string[] books = ReadBooksFromCSVFile().Split('\n');
            List<Book> list = new List<Book>();
            foreach (string s in books)
            {
                if (s.Length > 0)
                {
                    list.Add(BookCsvToObject(s, separator));
                }
            }
            return list;
        }

        public static void SerializeListToJson(List<Book> list, string fileName)
        {
            TextWriter writer = new StreamWriter(fileName);
            // static method SerilizeObject van Newtonsoft.Json
            string BookString = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            writer.WriteLine(BookString);
            writer.Close();
        }
        public static List<Book> DeserializeJsonToList(string fileName)
        {
            Helpers.Tekstbestand bestand = new Helpers.Tekstbestand();
            bestand.FileName = fileName;
            bestand.Lees();
            List<Book> list =  Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>(bestand.Text);
            return list;
        }
        public static void ShowBooks(List<Book> list)
        {
            foreach (Book item in list)
            {
                Console.WriteLine($"{item?.Title} - {item?.Year} - {item?.City} " +
                    $"{item?.Publisher} - {item?.Author} - {item?.Edition} - {item?.Translator} - {item?.Comment}");
            }
        }
    }

}