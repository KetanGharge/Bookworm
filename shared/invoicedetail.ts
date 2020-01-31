export class Invoicedetail {

    constructor(
        public invoicedetailsid: number,
        public amount: number,
        public product_productid: number,
        public invoiceheader_invoiceheaderid: number
        )
        {}
    }
