﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoWebApi.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}