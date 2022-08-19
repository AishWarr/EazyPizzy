using System;
using System.Collections.Generic;

#nullable disable

namespace OrderService.EFModels
{
    public partial class Outlet
    {
        public int Id { get; set; }
        public string OutletName { get; set; }
        public string OutletAddress { get; set; }
        public bool? IsActive { get; set; }
    }
}
