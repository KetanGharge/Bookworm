import { IMyshelf } from './imyshelf';

export class Myshelf implements IMyshelf {

     
    constructor(
        public myshelfid :number,
        public purchasedate :Date,
        public enddate :Date,
        public purchasetype :string,
        public rating :number,
        public product_productid :number,
        public customer_customerid : number,
        public invoiceheader_invoiceheaderid:number
       
    )
    {

    }

}
