//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trainer.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SchedulePerformance
    {
        public int Id { get; set; }
        public int PerformanceId { get; set; }
        public System.TimeSpan Time { get; set; }
        public int EmployeeId { get; set; }
        public Nullable<int> AnimalId { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Performance Performance { get; set; }
    }
}
