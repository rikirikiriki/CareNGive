//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareNGive
{
    using System;
    using System.Collections.Generic;
    
    public partial class Advertisement
    {
        public int AdID { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int TypeID { get; set; }
        public string AdName { get; set; }
        public string Description { get; set; }
        public Nullable<short> Quantity { get; set; }
        public int ContactID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string Image { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual Type Type { get; set; }
        public virtual User User { get; set; }
    }
}