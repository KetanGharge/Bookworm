import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Products } from '../shared/products';
import { IProducts } from '../shared/iproducts';

import {Router} from '@angular/router';
import { SharingService } from '../sharing.service';
import { Myshelf } from '../shared/myshelf';
import { IMyshelf } from '../shared/imyshelf';




@Component({
  selector: 'app-myshelf',
  templateUrl: './myshelf.component.html',
  styleUrls: ['./myshelf.component.css']
})
export class MyshelfComponent implements OnInit {

  product : IProducts[];
  productdata : any;
  productarray =[];
  productarray1 =[];
  condition :boolean= true;
  myshelf :IMyshelf;
  myshelfarray =[];
  minday:number;
  clicked:boolean;
  userdate:number;
  
  
   


  constructor(private _productservice : ProductService, private _router:Router, private _sharing:SharingService) { }

  ngOnInit() {

    this._productservice.getProduct()
      .subscribe(data =>
        { 
          this.product = data;
          this.productdata = data;
         
        })


  }


  onAddToCart(a:any)
  {
   // this.productarray.push(a);
   this.clicked=false;
   this.productarray.push(a);
    console.log(this.productarray.length);
    localStorage.setItem('cartproduct',JSON.stringify(this.productarray));
    this.productarray1 = JSON.parse(localStorage.getItem('cartproduct'));
    console.log(this.productarray1);
  }

  onRentClick(rentdata:any)
  {
    console.log(rentdata);
    this.minday= rentdata.rentmindays;
    console.log(this.minday);
    this.myshelf =new Myshelf(1,null,null,'rent',3,rentdata.productid,1,0); 
    console.log(this.myshelf);
    this.myshelfarray.push(this.myshelf);
    console.log(this.myshelfarray);
    this._productservice.postMyShelf(this.minday+this.userdate,this.myshelfarray).subscribe(data => {
      console.log(data)});
    
  }

  onRentButtonClick()
  {
       //var cartdata = JSON.parse(localStorage.getItem('cartproduct'));
      //               cartdata.productid
      this.condition =false;

  }

  onChange(event:any)
    {
      this.userdate=parseInt(event.target.value);

    }



}


