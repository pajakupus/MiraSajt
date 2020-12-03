import { Component, OnInit } from '@angular/core';
import { IProduct } from './../shared/models/product';
import { ShopParams } from './../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  constructor(private shopService: ShopService) { }

  products: IProduct[];
//  brands: IBrand[];
 // types: IType[];
  shopParams = new ShopParams();
  totalCount: number;
  sortOptions = [
    {name: 'Allphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAscending'},
    {name: 'Price: High to Low', value: 'priceDescending'}
  ];

  selected: HTMLElement;
  optionsContainer: HTMLElement;
  optionsList: HTMLElement;

  ngOnInit(): void {
   // this.getBrands();
   this.getProducts();
   // this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe(response => {
      this.products = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });

  }

  select() {
    this.optionsContainer = document.querySelector('.options-container');
    this.optionsContainer.classList.toggle('active');
  }

  toggle($event) {
    this.optionsContainer = document.querySelector('.options-container');
    this.selected = document.querySelector('.selected');
    this.selected.innerHTML = $event.target.innerHTML;
    this.optionsContainer.classList.remove('active');
    console.log(this.selected.innerHTML);
  }
}

