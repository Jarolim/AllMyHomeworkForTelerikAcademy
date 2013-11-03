﻿using LaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.ViewModels
{
    public class ListPageViewModel
    {
        public IEnumerable<LaptopIndexViewModel> Laptops { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public bool IsSearch { get; set; }
    }
}