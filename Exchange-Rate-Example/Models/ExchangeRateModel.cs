using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exchange_Rate_Example.Models
{
    public class ExchangeRateModel
    {
        public string RateTypeName { get; set; }
        public string Names { get; set; }
        public decimal Buying { get; set; }
        public decimal Selling { get; set; }
        public decimal Changing { get; set; }
    }
}