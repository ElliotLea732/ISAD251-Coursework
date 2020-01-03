using System;
using System.Collections.Generic;

namespace CafeWebApp.Models
{
    public partial class ItemOrder
    {
        public int ItemOrderId { get; set; }
        public int OrderMainId { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }

        public virtual Stock Item { get; set; }
        public virtual Orders OrderMain { get; set; }
    }
}
