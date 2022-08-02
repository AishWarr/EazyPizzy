using System;
using System.Collections.Generic;

#nullable disable

namespace OrderService.Models
{
    public partial class ToppingsInvetoryList
    {
        public int Id { get; set; }
        public string ToppingName { get; set; }
        public string ToppingDescription { get; set; }
        public int? ToppingTypeId { get; set; }
        public bool? IsNonVeg { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? ToppingCost { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ToppingType ToppingType { get; set; }
    }
}
