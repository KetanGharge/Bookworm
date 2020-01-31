import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';
import { CommentStmt } from '@angular/compiler';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  data:any;
  name:string;
  log_out: string;
  usermyshelf:string;
  namedisable:boolean=false;

  
  constructor(private _router : Router) { 
  }

  ngOnInit() {

  
  }
  ngDoCheck()
  {
    this.data= JSON.parse(localStorage.getItem('customerdata'));
    console.log(this.data);
    if(this.data)
    {
      this.name = 'Welcome '+this.data.fname;
      this.namedisable = true;
      this.log_out = 'Logout';
      this.usermyshelf  = 'MyShelf';
      
      
    }
    else
    {
      this.name = 'Sign In';
    }

  }

  logout()
  {
    
    localStorage.removeItem('customerdata');
    this._router.navigate(['/login']);
    let cart_data =localStorage.getItem('cartdata');   
    if(cart_data)
    {
      localStorage.removeItem('cartdata');
    }

  }
  

  

 

}
