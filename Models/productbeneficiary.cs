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
    
    public partial class productbeneficiary
    {
        public productbeneficiary()
        {
            this.beneficiarycalculations = new HashSet<beneficiarycalculation>();
        }
    
        public short productbeneficiaryid { get; set; }
        public int royalty { get; set; }
        public short beneficiary_beneficiaryid { get; set; }
        public short product_productid { get; set; }
    
        public virtual beneficiary beneficiary { get; set; }
        public virtual ICollection<beneficiarycalculation> beneficiarycalculations { get; set; }
        public virtual product product { get; set; }
    }
}
