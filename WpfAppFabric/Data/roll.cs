//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppFabric.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class roll
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public roll()
        {
            this.storageRoll = new HashSet<storageRoll>();
        }
    
        public double id { get; set; }
        public int IdCompound { get; set; }
        public int idColor { get; set; }
        public int width { get; set; }
        public int length { get; set; }
    
        public virtual color color { get; set; }
        public virtual compound compound { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<storageRoll> storageRoll { get; set; }
    }
}