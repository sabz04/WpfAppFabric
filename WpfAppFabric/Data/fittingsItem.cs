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
    
    public partial class fittingsItem
    {
        public string codeFittings { get; set; }
        public string codeItem { get; set; }
        public string placement { get; set; }
        public Nullable<int> width { get; set; }
        public Nullable<int> length { get; set; }
        public Nullable<int> rotation { get; set; }
        public int count { get; set; }
    
        public virtual fittings fittings { get; set; }
        public virtual item item { get; set; }
    }
}
