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
                {
                    title = "";
                }
                else
                {
                    string text = value.Replace("\n", string.Empty).TrimStart();
                    //use regex to replace all double spaces
                    title = Regex.Replace(text, @"\s+", " ");
                }

            }
        }
        public string Year { get; set; }
        public string City { get; set; }
        public string Publisher { get; set; }
        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                author = value.Replace("\n", string.Empty).Replace("  ", " ").TrimStart();
            }
        }
        public string Edition { get; set; }
        public string Translator { get; set; }
        public string Comment { get; set; }
        public static List<Book> List { get; set; } = new List<Book>();
    }
}
