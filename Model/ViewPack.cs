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
    
    public partial class ViewPack
    {
        public ViewPack()
        {
            this.Account = new HashSet<Account>();
        }
    
        public int IdPack { get; set; }
        public string NamePack { get; set; }
    
        public virtual ICollection<Account> Account { get; set; }
    }
}
