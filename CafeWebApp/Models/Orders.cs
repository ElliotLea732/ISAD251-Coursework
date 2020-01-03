using System;
using System.Collections.Generic;

namespace CafeWebApp.Models
{
    public partial class Orders
    {
        public Orders()
        {
            ItemOrder = new HashSet<ItemOrder>();
        }

        public int OrderMainId { get; set; }
        public decimal OrderCost { get; set; }

        public virtual ICollection<ItemOrder> ItemOrder { get; set; }
    }
}
