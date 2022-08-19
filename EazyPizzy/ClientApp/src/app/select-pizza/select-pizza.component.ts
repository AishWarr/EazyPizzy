import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-select-pizza",
  styleUrls: ["./select-pizza.component.scss"],
  templateUrl: "./select-pizza.component.html",
})
export class SelectPizzaComponent {
  public inventoryItems: InventoryList[];
  public isVeg: boolean = false;
  public showList: boolean = false;
  public currentOrder: Order;
  public httpClient: HttpClient;
  value = 1;
  prevOrder: Order;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.httpClient = http;
    this.getInventory();
    this.startNewOrder();
  }

  isVegg(a) {
    this.isVeg = a;
  }

  handleMinus(index) {
    if(this.currentOrder.pizzaList[index].quantity > 1)
      this.currentOrder.pizzaList[index].quantity--;
  }

  handlePlus(index) {
    this.currentOrder.pizzaList[index].quantity++;
  }

  async getInventory() {
    this.httpClient
      .get<InventoryList[]>("http://localhost:65008/Inventory")
      .subscribe(
        (result) => {
          this.inventoryItems = result;
          this.inventoryItems = this.inventoryItems.map(function (val, index) {
            val.isSelected = false;
            return val;
          });
        },
        (error) => console.error(error)
      );
  }

  async startNewOrder() {
    this.prevOrder = this.currentOrder;
    this.currentOrder = new Order();
    this.addOrderItem();
  }

  async addOrderItem() {
    let item = new CustomPizza();
    item.isVeg = false;
    item.quantity = 1;
    //let currentInventoryList = getInventory();else {
      this.httpClient
        .get<InventoryList[]>("http://localhost:65008/Inventory")
        .subscribe(
          (result) => {
            this.inventoryItems = result;
            this.inventoryItems = this.inventoryItems.map(function (
              val,
              index
            ) {
              val.isSelected = false;
              return val;
            });
            item.toppingList = [];
            var toppings = [];
            item.toppingList = this.inventoryItems;
            this.currentOrder.pizzaList.push(item);
          },
          (error) => console.error(error)
        );
  }

  removeOrderItem(index){
    this.currentOrder.pizzaList.splice(index, 1);
  }

  addToSelected(item,index){
    //Not selected yet
    if(!item.isSelected)
      this.currentOrder.pizzaList[index].selectedToppingList.push(item);
    //Not unselected yet
    if(item.isSelected)
    {
      var toppingIndex = this.currentOrder.pizzaList[index].selectedToppingList.findIndex(x=>x.id == item.id);
      this.currentOrder.pizzaList[index].selectedToppingList.splice(toppingIndex,1);
    }
  }

  submit(){
    this.currentOrder.outletId = parseInt(environment.outlet);
    const httpOptions = {
      headers: new HttpHeaders().append('content-type', 'application/json')
    }
    const json = JSON.stringify(this.currentOrder);
    this.httpClient
        .post("http://localhost:11022/Order",json, httpOptions)
        .subscribe((result: Order) => {
          window.alert("Order Confirmed!! Token number :" + result.tokenNo);
          this.currentOrder = null;
          this.startNewOrder();
        },
        (error) => console.error(error)
      );
  }
}

class InventoryList {
  id: number;
  toppingName: string;
  toppingTypeId: number;
  isNonVeg: boolean;
  isSelected: boolean;
}

class CustomPizza {
  isVeg: boolean = false;
  itemNo: number;
  toppingList: InventoryList[];
  selectedToppingList: InventoryList[] = [];
  quantity: number;
}

class Order {
  orderNo: number;
  pizzaList: CustomPizza[] = [];
  tokenNo: number;
  outletId: number;
  orderDate: Date;
}
