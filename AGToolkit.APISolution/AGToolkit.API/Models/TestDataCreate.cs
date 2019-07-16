using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGToolkit.API.Models
{
    public class TestDataCreate
    {
        public double FretAmount { get; set; }
        public double ScaleLength { get; set; }
    }

    public class TestDataCreateResponse
    {
        public double FretAmount { get; set; }
        public double ScaleLength { get; set; }
    }
}

