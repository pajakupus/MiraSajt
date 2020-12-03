import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from '../../shared/models/product';
import { ShopService } from '../shop.service';
import { ISize } from '../../shared/models/productSize';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  quantity = 1;
  selected: HTMLElement;
  optionsContainer: HTMLElement;
  optionsList: HTMLElement;
  
  constructor(private shopService: ShopService,
              private activateRoute: ActivatedRoute,
              private basketService: BasketService
              ) { }

  ngOnInit(): void {
    this.loadProduct();
  }
  //this.basketService.deleteLocalBasket('8b4e6685-9250-4e30-a0ed-64da56d89c8f');

  loadProduct() {
    this.shopService.getProduct(+this.activateRoute.snapshot.paramMap.get('id')).subscribe( product => {
      this.product = product;
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
    //console.log(this.selected.innerHTML);
  }

  addItemToCart() {
    if (this.selected) {
      this.basketService.addItemToBasket(this.product, this.quantity, this.selected.innerHTML);
    } else {
      console.log('Select size');
    }
   
  }

  incrementQuantity() {
    this.quantity++;
  }
  decrementQuantity() {
    if(this.quantity > 1)
    this.quantity--;
  }
}
    // const selected = document.querySelector(".selected");
    // const optionsContainer = document.querySelector(".options-container");

    // const optionsList = document.querySelectorAll(".option");

    // selected.addEventListener("click", () => {
    //   optionsContainer.classList.toggle("active");
    // });

    // optionsList.forEach(o => {
    //   o.addEventListener("click", () => {
    //     selected.innerHTML = o.querySelector("label").innerHTML;
    //     optionsContainer.classList.remove("active");
    //   });
    // });


