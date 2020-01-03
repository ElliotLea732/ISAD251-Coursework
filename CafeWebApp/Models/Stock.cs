using System;
using System.Collections.Generic;

namespace CafeWebApp.Models
{
    public partial class Stock
    {
        public Stock()
        {
            ItemOrder = new HashSet<ItemOrder>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemPrice { get; set; }
        public int? ItemStock { get; set; }
        public string ItemType { get; set; }

        public virtual ICollection<ItemOrder> ItemOrder { get; set; }
    }
}
