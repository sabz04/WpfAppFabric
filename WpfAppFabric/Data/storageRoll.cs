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
    
    public partial class storageRoll
    {
        public double idRoll { get; set; }
        public string codeCloth { get; set; }
        public int count { get; set; }
    
        public virtual cloth cloth { get; set; }
        public virtual roll roll { get; set; }
    }
}
