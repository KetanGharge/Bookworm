import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { load, pureFunction1, element } from '@angular/core/src/render3';
import { Myshelf } from '../shared/myshelf';
import { IProducts } from '../shared/iproducts';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {

  myshelfpurchase:Myshelf[]=[];
  mydata : IProducts[]=[];
  custdata:any;


  temp:any;
  // custdata :any; 
  constructor(private _productservice: ProductService) { }

  ngOnInit() {

     this.custdata = JSON.parse(localStorage.getItem('customerdata'));
    console.log('customerId',this.custdata.customerid);
    //this.getdata();

    this.temp=this._productservice.getPurchaseBook(this.custdata.customerid,'purchase').toPromise().then(
      data=>{
        this.myshelfpurchase=data;
        console.log('purchase data55',data);

        this.myshelfpurchase.forEach( element => {
          console.log(element.product_productid);

          this._productservice.getProductById(element.product_productid).subscribe(data=>{
              this.mydata.push(data);
              console.log('getproductbyid',data);  
          });
        });
      });
    console.log(this.temp);


    // this._productservice.getPurchaseBook(this.custdata.customerid,'purchase').subscribe(data =>
    //   {
    //     this.myshelfpurchase=data;
    //     console.log('purchase data55',data);
    //     this.myshelfpurchase.forEach(element => {
    //       console.log(element.product_productid);
    //       this._productservice.getProductById(element.product_productid).subscribe(data=>{
    //           this.mydata.push(data);
    //           console.log('getproductbyid',data);    
    //       });
    //     });
    //   });
     
  }
  

  // public getdata()
  // {
  //   this._productservice.getPurchaseBook(this.custdata.customerid,'purchase').subscribe(data =>
  //     {
  //       this.myshelfpurchase=data;
  //       console.log('purchase data55',data);
  //     });
      
  //     this.myshelfpurchase.forEach(element =>
  //       {
  //         console.log('eleele',element);
  //         this._productservice.getProductById(element.product_productid).subscribe(data =>
  //           {
  //             this.mydata.push(data);

  //           })
  //       })

  // }
  // ngDoCheck()
  // {
  //          this.myshelfpurchase.forEach(element => {
  //         console.log(element.product_productid);
  //         this._productservice.getProductById(element.product_productid).subscribe(data=>{
  //             this.mydata.push(data);
  //             console.log('getproductbyid',data);    
  //         });
  //       });
    
  // }

}
