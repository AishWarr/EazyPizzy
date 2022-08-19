using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace OrderService.EFModels
{
    public partial class Order
    {
        public Order()
        {
            Pizzas = new HashSet<Pizza>();
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key]

        public int Id { get; set; }
        public int? OrderNo { get; set; }
        public int? OutletId { get; set; }
        public int? TokenNo { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
