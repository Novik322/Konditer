//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Konditer_FigmaProject.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public int IdAccount { get; set; }
        public int IdProduct { get; set; }
        public int IdPack { get; set; }
        public int Count { get; set; }
        public string Weight { get; set; }
        public int IdUnit { get; set; }
        public decimal Price { get; set; }
        public System.DateTime DateManufact { get; set; }
        public System.DateTime DateReal { get; set; }
        public System.DateTime DateOtgruz { get; set; }
        public int IdOptSalers { get; set; }
    
        public virtual OptSalers OptSalers { get; set; }
        public virtual Products Products { get; set; }
        public virtual Units Units { get; set; }
        public virtual ViewPack ViewPack { get; set; }
    }
}