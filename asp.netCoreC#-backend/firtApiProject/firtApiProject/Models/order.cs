using System;
using System.Collections.Generic;

namespace firtApiProject.Models
{
    public partial class order
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int number { get; set; }
        public int price { get; set; }
        public string? imgurl { get; set; }
        public int userId { get; set; }
    }
}
