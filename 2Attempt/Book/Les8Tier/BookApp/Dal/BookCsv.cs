using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookApp.Dal
{
    class BookCsv : IBook
    {
        // Een Book BLL object om de opgehaalde waarden
        // in op te slagen
        public Bll.Book Book { get; set; }
        // Error message
        public string Message { get; set; }
        private string connectionString = @"Data/Book";
        public string ConnectionString
        {
            get
            {
                return connectionString + ".csv";
            }
            set
            {
                connectionString = value;
            }
        }

        public char Separator { get; set; } = '|';

        public BookCsv(Bll.Book book)
        {
            Book = book;
        }

        public bool ReadAll()
        {
            Helpers.Tekstbestand bestand = new Helpers.Tekstbestand();
            bestand.FileName = ConnectionString;
            if (bestand.Lees())
            {
                string[] books = bestand.Text.Split('\n');
                try
                {
                    List<Bll.Book> list = new List<Bll.Book>();
                    foreach (string s in books)
                    {
                        if (s.Length > 0)
                        {
                            list.Add(ToObject(s));
                        }
                    }

                    Book.List = list;

                    Message = $"Het bestand {ConnectionString} is gedesialiseerd!";
                    return true;
                }
                catch (Exception e)
                {
                    // Melding aan de gebruiker dat iets verkeerd gelopen is.
                    // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                    Message = $"Bestand {ConnectionString} is niet gedeserialiseerd.\nFoutmelding {e.Message}.";
                    return false;
                }
            }
            else
            {
                Message = $"Bestand {ConnectionString} is niet gedeserialiseerd.\nFoutmelding {bestand.Melding}.";
                return false;
            }
        }
        /// <summary>
        /// create a lin in a csv with all the values
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private Bll.Book ToObject(string line)
        {
            Bll.Book book = new Bll.Book();
            string[] values = line.Split(Separator);
            book.Title = values[0];
            book.Author = values[1];
            book.Year = values[2];
            book.City = values[3];
            book.Publisher = values[4];
            return book;
        }

        /// <summary>
        /// creata the csv file from the list
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            try
            {
                TextWriter writer = new StreamWriter(ConnectionString);
                foreach (Bll.Book item in Book.List)
                {
                    // One of the most versatile and useful additions to the C# language in version 6
                    // is the null conditional operator ?.Post           
                    writer.WriteLine($"{item?.Title}{Separator}{item?.Author}{Separator}{item?.Year}{Separator}" +
                        $"{item?.City}{Separator}{item?.Publisher}{Separator}");
                }
                writer.Close();
                Message = $"Het bestand met de naam {ConnectionString} is geserialiseerd!";
                return true;
            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                Message = $"Bestand met naam {ConnectionString} niet geserialiseerd.\nFoutmelding {e.Message}.";
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public bool Create(char separator = '|')
        {
            Separator = separator;
            return Create();
        }

    }
}
