import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { HomeComponent } from './home/home.component';
import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';

import { BasketWidgetComponent } from './basket-widget/basket-widget.component';
import { BasketComponent } from './basket/basket.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { FooterComponent } from './footer/footer.component';
import { ShopModule } from './shop/shop.module';
import { OrdersComponent } from './orders/orders.component';
import { OrdersModule } from './orders/orders.module';


@NgModule({
  declarations: [
    AppComponent,
    AdminPanelComponent,
    BasketWidgetComponent,
    BasketComponent,
    CheckoutComponent,
    LoginComponent,
    SignupComponent,
    HomeComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    ShopModule,
    OrdersModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
