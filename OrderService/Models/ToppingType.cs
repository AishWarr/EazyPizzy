using System;
using System.Collections.Generic;

#nullable disable

namespace OrderService.Models
{
    public partial class ToppingType
    {
        public ToppingType()
        {
            ToppingsInvetoryLists = new HashSet<ToppingsInvetoryList>();
        }

        public int Id { get; set; }
        public string ToppingTypeName { get; set; }
        public string ToppingTypeDescripion { get; set; }
        public bool? IsAvailable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<ToppingsInvetoryList> ToppingsInvetoryLists { get; set; }
    }
}
