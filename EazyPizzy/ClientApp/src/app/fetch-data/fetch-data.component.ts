import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  styleUrls: ['./fetch-data.component.scss'],
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public inventoryItems: InventoryList[];
  public isVeg: boolean = null;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      http.get<InventoryList[]>('http://localhost:65008/Inventory').subscribe(result => {
      this.inventoryItems = result;
    }, error => console.error(error));
  }

  isVegg(a){
    this.isVeg = a;
  }
}

interface InventoryList {
  id: number;
  toppingName: string;
  toppingTypeId: number;
  isNonVeg: boolean;
}
