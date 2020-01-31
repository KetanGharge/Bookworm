import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProducts } from './shared/iproducts';
import { Observable } from 'rxjs';
import { IMyshelf } from './shared/imyshelf';
import { IInvoicedetail } from './shared/iinvoicedetail';
import { Myshelf } from './shared/myshelf';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  readonly URL = 'http://localhost:50950/api/Product';
  readonly URL1 = 'http://localhost:50950/api/myshelf';
  readonly URL2 = 'http://localhost:50950/api/myshelf';
  
  readonly URL3 = 'http://localhost:50950/api/invoiceheader';

  


  constructor(private _http: HttpClient) { }


  getProduct():Observable<IProducts[]>
  {
    
    return this._http.get<IProducts[]>(this.URL);
  }

  postMyShelf(minday,obj)
  {
    return this._http.post(this.URL1+'?days='+minday,obj);
  }

  getPurchaseBook(cid,purchasetype)
  {
    return this._http.get<IMyshelf[]>(this.URL2+'?cid='+cid+'&purchasetype='+purchasetype);
  }

  getProductById(pid)
  {
    return this._http.get<IProducts>(this.URL+'?id='+pid);
  }

  getInvoice(cid):Observable<IInvoicedetail[]>
  {
    return this._http.get<IInvoicedetail[]>(this.URL3+'?id='+cid);
  }

  getInvoice1(cid,purchasetype):Observable<IMyshelf[]>
  {
    return this._http.get<IMyshelf[]>(this.URL2+'?id='+cid+'&purchasetype='+purchasetype);
  }


}
