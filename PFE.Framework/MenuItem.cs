﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework
{
    public class MenuItem
    {
        public string Title { get; set; }
        public IList<MenuChildItem> Childs { get; set; }
    }
}
