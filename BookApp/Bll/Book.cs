using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Bll
{
    public class Book
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string City { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Translator { get; set; }
        public string Comment { get; set; }
        private List<Book> list;

        public List<Book> List 
        {
            get { return list; }
            set { list = value; }
        }

    }
}
