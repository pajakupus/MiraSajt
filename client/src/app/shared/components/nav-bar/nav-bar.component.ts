import {Component, OnInit } from '@angular/core';
import {Location} from '@angular/common';



@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  underline: HTMLElement;
  item: any;
  location: string;
  nav: any;
  
  

  constructor(private loc: Location) { 
   this.location = loc.path();
    
  }

  ngOnInit(): void {
    this.underline = document.querySelector<HTMLElement>('.underline');
    this.smartLine();
    this.onStartLine();
    // this.nav = document.querySelectorAll('.nav-menu-item');
    // this.nav.forEach(element => { console.log(element);
      
    // });
    }

  ngAfterViewInit(): void {

  }
  ngAfterViewChecked() : void {
    
  }

  handleUnderline(element) {
    this.underline.style.width = "".concat(element.offsetWidth, "px");
    this.underline.style.left = "".concat(element.offsetLeft, "px");
  }
  onClick($event) {
    this.handleUnderline($event.target);
    // this.nav = document.querySelectorAll('.nav-menu-item');
    // this.nav.forEach(element => { console.log(element.classList.contains('active'));});
  }

  smartLine() {
    this.item = document.querySelectorAll('.active')
    this.underline.style.width = "".concat(this.item.offsetWidth, "px");
    this.underline.style.left = "".concat(this.item.offsetLeft, "px");
  }

  onStartLine() {
   // if(this.nav.classList.contains)
   if(this.location.includes('/shop')) {
     //console.log(this.location);
   }
  }
}
