//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RCMS.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string ImageLink { get; set; }
        public Nullable<int> Sequence { get; set; }
        public Nullable<bool> IsPublished { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public Nullable<int> HitCount { get; set; }
        public Nullable<System.DateTime> LastUpdateOn { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
