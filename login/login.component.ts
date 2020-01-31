import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
rForm: FormGroup;
  errorMsg: string;
  usernameError: string = 'Username is required.';
  passwordError: string = 'Your password must be 6-8 character long.';                     // A property for our submitted form
  password: string = '';
  name: string = '';



  constructor(private fb : FormBuilder, private logInService: LoginService, private _router:Router) {

    this.rForm = fb.group({
        'emailid': [null, Validators.required],
        'password': [null, Validators.compose([Validators.required, Validators.minLength(6), Validators.maxLength(8)])]
    });
    
   
   }

  ngOnInit() {
  }

  signIn(value: any) {
    this.logInService.signIn(value)
        .subscribe(
            (succ: any) => {
                console.log(succ);
                
                localStorage.setItem('customerdata',JSON.stringify(succ));
                
                this._router.navigate(['/']);
            },
            (err) => {
                console.log(err);
                if (err.status == 404 || 401)
                    this.errorMsg = err.error.message;
                setTimeout(() => {
                    this.errorMsg = null;
                }, 3000);
            }
        );
}

}