import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { BookwormService } from './shared/bookworm.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SignupComponent } from './signup/signup.component';
import { RouterModule } from '@angular/router';
import { LoginService } from './login.service';
import { AuthGuard } from './auth.guard';
import { SliderComponent } from './slider/slider.component';
import { MyshelfComponent } from './myshelf/myshelf.component';
import { ProductService } from './product.service';
import { CartComponent } from './cart/cart.component';
import { SharingService } from './sharing.service';
import { BuybooksComponent } from './buybooks/buybooks.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { RentComponent } from './rent/rent.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    SignupComponent,
    SliderComponent,
    MyshelfComponent,
    CartComponent,
    BuybooksComponent,
    PurchaseComponent,
    RentComponent,
    InvoiceComponent,
   
   
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule,
    AngularFontAwesomeModule
    

    
  ],
  providers: [BookwormService,LoginService,AuthGuard,ProductService,SharingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
