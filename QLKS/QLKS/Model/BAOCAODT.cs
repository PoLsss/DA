//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLKS.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BAOCAODT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BAOCAODT()
        {
            this.CTBAOCAODTs = new HashSet<CTBAOCAODT>();
        }
    
        public string MaBaoCao { get; set; }
        public string TenBaoCao { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public Nullable<System.DateTime> ThangBaoCao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBAOCAODT> CTBAOCAODTs { get; set; }
    }
}
