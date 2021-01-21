using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Dal
{
    interface IBook
    {
        public Bll.Book Book { get; set; }
        public string Message { get; set; }
        public string ConnectionString { get; set; }

        bool Create();

        bool ReadAll();
    }
}
