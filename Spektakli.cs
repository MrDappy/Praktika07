//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Praktika07
{
    using System;
    using System.Collections.Generic;
    
    public partial class Spektakli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Spektakli()
        {
            this.JobActorsTheatre = new HashSet<JobActorsTheatre>();
        }
    
        public int ID_spektaklya { get; set; }
        public string NameSP { get; set; }
        public Nullable<System.DateTime> YearProduction { get; set; }
        public Nullable<decimal> Budget { get; set; }
        public byte[] ImagePreview { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobActorsTheatre> JobActorsTheatre { get; set; }
    }
}
