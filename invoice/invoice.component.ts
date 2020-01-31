import { Component, OnInit } from '@angular/core';
import { IInvoicedetail } from '../shared/iinvoicedetail';
import { ProductService } from '../product.service';
import { IMyshelf } from '../shared/imyshelf';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {

  invoicedetail:IInvoicedetail[]=[];
  customerdata:any;
  myshe:IMyshelf[]=[];
  constructor(private _productService:ProductService) { }

  ngOnInit() {
    this.customerdata=JSON.parse(localStorage.getItem('customerdata'));
    console.log(this.customerdata.customerid);
    this._productService.getInvoice(this.customerdata.customerid).subscribe(data=>{
      console.log(data);
      this.invoicedetail = data;

    });

    this._productService.getInvoice1(this.customerdata.customerid,'purchase').subscribe(
      data =>{
        this.myshe=data;
        console.log('myshlef',data);
      }
    );
  }

  getProduct(pid)
  {}


}
