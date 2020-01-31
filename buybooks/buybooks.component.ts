import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-buybooks',
  templateUrl: './buybooks.component.html',
  styleUrls: ['./buybooks.component.css']
})
export class BuybooksComponent implements OnInit {

  custdata:any;
  constructor(private _productservice : ProductService,private _router :Router) { }

  ngOnInit() {
    
      
    this.custdata=JSON.parse(localStorage.getItem('customerdata'));
    // if(!this.custdata)
    // {
    //   this._router.navigateByUrl("['/']");
      
    // }
    console.log(this.custdata);
  }

  onCategoryChange(purchasetype:string)
  {
       
  }





}
