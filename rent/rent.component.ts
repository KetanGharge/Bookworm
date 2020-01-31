import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Myshelf } from '../shared/myshelf';
import { IProducts } from '../shared/iproducts';

@Component({
  selector: 'app-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.css']
})
export class RentComponent implements OnInit {

  myshelfpurchase:Myshelf[]=[];
  mydata : IProducts[]=[];
  custdata:any;
  constructor(private _productservice : ProductService) { }

  ngOnInit() {
    // let custdata = JSON.parse(localStorage.getItem('customerdata'));
    // console.log('customerId',custdata.customerid);
    // this._productservice.getPurchaseBook(custdata.customerid,'rent').subscribe(data =>
    //   {
    //     this.myshelfpurchase=data;
    //     console.log('rent data',data);
    //     this.myshelfpurchase.forEach(element => {
                    
    //                   this._productservice.getProductById(element.product_productid).subscribe(data=>{
    //                       this.mydata.push(data);
    //                      console.log('getproductbyid',data);    
    //                   });
    //     });
    //   });
    this.custdata = JSON.parse(localStorage.getItem('customerdata'));
    console.log('customerId',this.custdata.customerid);
    this._productservice.getPurchaseBook(this.custdata.customerid,'rent').toPromise().then(
      data=>{
        this.myshelfpurchase=data;
           console.log('rent data',data);
          this.myshelfpurchase.forEach(element=>
            {
              this._productservice.getProductById(element.product_productid).subscribe(data=>{
              this.mydata.push(data);
              console.log('getproductbyid',data);    
            });
         });
      });
  }
}
