//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bookwrm_03.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class invoiceheader
    {
        public invoiceheader()
        {
            this.invoicedetails = new HashSet<invoicedetail>();
            this.myshelves = new HashSet<myshelf>();
        }
    
        public short invoiceheaderid { get; set; }
        public System.DateTime date { get; set; }
        public double totalamount { get; set; }
        public short customer_customerid { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual ICollection<invoicedetail> invoicedetails { get; set; }
        public virtual ICollection<myshelf> myshelves { get; set; }
    }
}
