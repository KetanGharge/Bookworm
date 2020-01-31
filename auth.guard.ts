import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { CanActivate, Router } from '@angular/router';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate{

  constructor(private _loginService:LoginService, private _router:Router)
  {

  }

  canActivate():boolean{
    if(this._loginService.loggedIn()){
      return true;
    }
    else {
      this._router.navigate(['/']);
      return false;
    }
  }
  
}
