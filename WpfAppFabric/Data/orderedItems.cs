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
    
    public partial class orderedItems
    {
        public string IdItem { get; set; }
        public int IdOrder { get; set; }
        public int count { get; set; }
    
        public virtual item item { get; set; }
        public virtual order order { get; set; }
    }
}