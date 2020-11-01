﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Dal
{
    public interface IBook
    {
        Bll.Book Book { get; set; }
        string Message { get; set; }
        string ConnectionString { get; set; }
        public char Separator { get; set; }

        bool Create();
        bool Create(char separator);
        bool ReadAll();
    }
}
