﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactAPI.Models
{
    public class AddressModel
    {
        public string Street { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public int Zip { get; set; }
    }
}