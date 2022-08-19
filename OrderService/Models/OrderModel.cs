namespace OrderService.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public CustomPizza[] PizzaList { get; set; }
        public int? TokenNo { get; set; }
        public int OutletId { get; set; }
        public string OrderDate { get; set; }
    }

    public class CustomPizza
    {
        public int ItemNo { get; set; }
        public InventoryList[] ToppingList { get; set; }
        public int Quantity { get; set; }
        public InventoryList[] SelectedToppingList { get; set; }
    }

    public class InventoryList
    {
        public int Id { get; set; }
        public bool IsSelected { get; set; }
        public string ToppingName { get; set; }

    }
}
