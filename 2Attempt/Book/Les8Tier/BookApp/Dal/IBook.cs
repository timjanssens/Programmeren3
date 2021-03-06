﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BookApp.Dal
{
    public interface IBook
    {
        Bll.Book Book { get; set; }
        public string Message { get; set; }
        public string ConnectionString { get; set; }

        bool Create();
        bool ReadAll();
    }
}
