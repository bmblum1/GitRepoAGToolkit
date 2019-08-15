﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AGToolkit.API.Data
{
    public class TestData
    {
        [Key]
        public int TestId { get; set; }
        public double FretAmount { get; set; }
        public double ScaleLength { get; set; }
    }
}