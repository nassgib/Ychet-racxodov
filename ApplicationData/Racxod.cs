//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ychet_racxodov.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Racxod
    {
        public int kod_racxoda { get; set; }
        public double cymma { get; set; }
        public System.DateTime data { get; set; }
        public int kod_otdela { get; set; }
        public int kod_vida { get; set; }
    
        public virtual Otdel Otdel { get; set; }
        public virtual Vid_racxodov Vid_racxodov { get; set; }
    }
}
