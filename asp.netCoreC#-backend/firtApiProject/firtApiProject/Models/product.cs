using System;
using System.Collections.Generic;

namespace firtApiProject.Models
{
    public partial class product
    {
        public string productCode { get; set; } = null!;
        public string? productName { get; set; }
        public int? stockNumber { get; set; }
        public int? purchasePrice { get; set; }
        public int? salePrice { get; set; }
        public string? kdv { get; set; }
        public int id { get; set; }
        public string? imgurl { get; set; }
    }
}
