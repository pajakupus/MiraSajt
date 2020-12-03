import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent},


  // { path: 'test-error', component: TestErrorComponent},


  // { path: 'server-error', component: ServerErrorComponent},


  // { path: 'not-found', component: NotFoundComponent},


  { path: 'shop', loadChildren: () => import('../app/shop/shop.module').then(mod => mod.ShopModule)},
 


   { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule)},

   {
    path: 'orders',
    //canActivate: [AuthGuard],
    loadChildren: () => import('./orders/orders.module')
      .then(mod => mod.OrdersModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
