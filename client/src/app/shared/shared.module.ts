import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { SocialMediaComponent } from './components/social-media/social-media.component';
import { BasketSummaryComponent } from './components/basket-summary/basket-summary.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';



@NgModule({
  declarations: [NavBarComponent, SocialMediaComponent, BasketSummaryComponent, OrderTotalsComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavBarComponent,
    SocialMediaComponent,
    OrderTotalsComponent,
    BasketSummaryComponent
  ]
})
export class SharedModule { }
