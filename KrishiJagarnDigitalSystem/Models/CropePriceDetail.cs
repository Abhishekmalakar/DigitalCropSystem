//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KrishiJagarnDigitalSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CropePriceDetail
    {
        public CropePriceDetail()
        {
            this.FormerDetails = new HashSet<FormerDetail>();
        }
    
        public int id { get; set; }
        public string SellingMandiName { get; set; }
        public Nullable<int> CropePrice { get; set; }
        public string TotalWeight { get; set; }
        public string Year { get; set; }
    
        public virtual ICollection<FormerDetail> FormerDetails { get; set; }
    }
}