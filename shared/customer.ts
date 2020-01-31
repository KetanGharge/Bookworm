import { ICustomer } from './icustomer';

export class Customer implements ICustomer{

    constructor(
        public customerid : number,
        public fname : string,
        public lname : string,
        public address : string,
        public age : number,
        public emailid : string,
        public password : string,
        public phoneno : string
    ){

    }
    
}
