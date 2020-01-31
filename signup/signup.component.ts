import { Component, OnInit } from '@angular/core';
import { BookwormService } from '../shared/bookworm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, NgForm } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  loginform : FormGroup;
  constructor(public _bookwormservice : BookwormService,
    private _activatedRoute: ActivatedRoute,private router:Router) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form? : NgForm){
    if(form!=null)
      form.resetForm();
    this._bookwormservice.customer = {
      customerid : null,
      fname : '',
      lname : '',
      address : '',
      age : null,
      emailid : '',
      password : '',
      phoneno : '',
    }
  }

  onSubmit(form : NgForm)
  {
      //localStorage.getItem('customerdata');
      this.insertRecord(form);
      
  }

  insertRecord(form : NgForm){
    this._bookwormservice.Postcustomer(form.value).subscribe(
        res => {
          this.resetForm(form)
        }   
    )
}

}
