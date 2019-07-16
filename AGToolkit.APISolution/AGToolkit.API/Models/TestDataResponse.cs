using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGToolkit.API.Models
{
    public class TestDataResponse
    {
        public List<TestDataResponseItem> Data { get; set; }
    }

    public class TestDataResponseItem
    {
        public double FretAmount { get; set; }
        public double ScaleLength { get; set; }
    }
}
