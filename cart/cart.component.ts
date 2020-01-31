import { Component, OnInit } from '@angular/core';
import { SharingService } from '../sharing.service';
import { ProductService } from '../product.service';
import { IMyshelf } from '../shared/imyshelf';
import { Myshelf } from '../shared/myshelf';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { getUrlScheme } from '@angular/compiler';
import { getTranslationForTemplate } from '@angular/core/src/render3/i18n';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  data:any;
 myshelfcart:IMyshelf;
  myshelfcartarray:IMyshelf[] = [];
  id : number;

  minday:any;
  temp :any;
  customerdata:any;

  sum :number=0;
  
  constructor(private _sharing : SharingService, private _productservice:ProductService,private _router:Router) { }

  ngOnInit() {
  
   this.temp= JSON.parse(localStorage.getItem('cartproduct'));
   this.customerdata= JSON.parse(localStorage.getItem('customerdata'));

  // console.log(this.temp.producttitle);


  }
  // public myshelfid :number,
  // public purchasedate :Date,
  // public enddate :Date,
  // public purchasetype :string,
  // public rating :number,
  // public product_productid :number,
  // public customer_customerid : number,
  // public invoiceheader_invoiceheaderid:number

  onCheckOut(cartdata:any){

console.log(cartdata);
    this.minday= 0;
    //console.log(this.minday);
    cartdata.forEach(element => {

       console.log(element);
     

    this.myshelfcart =new Myshelf(0,null,null,'purchase',3,element.productid,this.customerdata.customerid,0);
    console.log(this.myshelfcart) 
    this.myshelfcartarray.push(this.myshelfcart);
    });
   
   // console.log(this.myshelfcartarray);
    
    // console.log(this.myshelfcartarray);
    this._productservice.postMyShelf(this.minday,this.myshelfcartarray).subscribe(data => {
   //  console.log(data);
      
      this.sum=0;
     alert("Payment Successfull");

     this._router.navigateByUrl('/buybook');
    });
  }


  getSum(data1:number)
  {
    this.sum+=data1;
  }

  onClear()
  {
    localStorage.removeItem('cartproduct');
    this.sum=0;
    // this._router.navigateByUrl('/cart');
  }
}
