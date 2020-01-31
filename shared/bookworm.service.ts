import { Injectable } from '@angular/core';
import { ICustomer } from './icustomer';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class BookwormService {

  customer : ICustomer
  readonly rootURL ="http://localhost:50950/api"
 
  constructor(private http : HttpClient) { 

  }

  Postcustomer(customer : ICustomer)
  {
    return  this.http.post(this.rootURL+'/Customer',customer);
  }

  Getcustomer(customer1 : ICustomer)
  {
    return this.http.get<ICustomer[]>(this.rootURL+'/Customer?emaild='+customer1.emailid+'password='+customer1.password);
  }



}
