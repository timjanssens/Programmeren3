using BookApp.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BookApp.Bll
{
    public class Book
    {
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                if (value == null)
                    title = "";
                else
                {
                    string text = value.Replace("\n", string.Empty).TrimStart();
                    text = Regex.Replace(text, @"\s+", " ");
                    title = text;
                }
                    ;
            }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string publisher;

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set
            {
                string text = value.Replace("\n", string.Empty).TrimStart();
                text = Regex.Replace(text, @"\s+", " ");
                author = text;
            }
        }

        private string edition;

        public string Edition
        {
            get { return edition; }
            set { edition = value; }
        }

        private string translator;

        public string Translator
        {
            get { return translator; }
            set { translator = value; }
        }

        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public List<Book> List { get; set; } = new List<Book>();

        public static implicit operator Book(BookXml v)
        {
            throw new NotImplementedException();
        }
    }
}
