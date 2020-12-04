import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './orders.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { NgModule } from '@angular/core';


const routes: Routes = [
    {path: '', component: OrdersComponent},
    // {path: '/:id', component:OrderDetailsComponent}
];

@NgModule({
    declarations: [],
    imports: [
      RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
  })
  export class OrdersRoutingModule { }