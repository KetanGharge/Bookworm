import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AuthGuard } from './auth.guard';
import { SliderComponent } from './slider/slider.component';
import { MyshelfComponent } from './myshelf/myshelf.component';
import { CartComponent } from './cart/cart.component';
import { BuybooksComponent } from './buybooks/buybooks.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { RentComponent } from './rent/rent.component';
import { InvoiceComponent } from './invoice/invoice.component';

const routes: Routes = [
  {path:'slider',component:SliderComponent},
  { path:'login', component:LoginComponent},
  { path:'signup', component:SignupComponent}, //canActivate:[AuthGuard]
  { path:'myshelf', component:MyshelfComponent},
  { path:'cart',component:CartComponent},
  {path:'buybook',component:BuybooksComponent},
  {path:'purchase',component:PurchaseComponent},
  {path:'rent',component:RentComponent},
  {path:'invoice',component:InvoiceComponent},
  { path: '', component:SliderComponent}

 /* {
    path:'dashboard',
    component:DashboardComponent,
    canActivate:[AuthGuard]
  }*/
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
