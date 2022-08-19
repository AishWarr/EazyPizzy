using System;
using System.Collections.Generic;

#nullable disable

namespace OrderService.EFModels
{
    public partial class Pizza
    {
        public int Id { get; set; }
        public string ToppingList { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
