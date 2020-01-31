import { Injectable, Output,EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { Observable, observable , of} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private api = 'http://localhost:50950/api/Customer?';
  private header = new Headers();

  @Output() getLoggedInName : EventEmitter<any> = new EventEmitter();

  constructor(private _http: HttpClient, private _router :Router) { }


  // Only This is used
  signIn(value)
{
  return this._http.post(this.api +'emailid='+value.emailid+'&password='+value.password, (value) );

}

// login():Observable<boolean>{
//  var name =JSON.parse(localStorage.getItem('customerdata'));
//   if(name)  
//   {
//     this.getLoggedInName.emit(name.fname);
//     return of(true);
//   }
//   else{
//     this.getLoggedInName.emit('Sign In');
//     return of(false);
//   }
// }


loggedIn() {
  return !!localStorage.getItem('token');
}

getToken() {
  return localStorage.getItem('token');
}

// logout() {
//   localStorage.removeItem('token');
//   this._router.navigate(['/']);
// }



}
