//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Director.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ItemId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Item Item { get; set; }
    }
}
