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
    
    public partial class TicketSale
    {
        public int Id { get; set; }
        public int PerformanceId { get; set; }
        public int ClientId { get; set; }
        public string LastNameClient { get; set; }
        public string FirstNameClient { get; set; }
        public string PatronymicClient { get; set; }
        public string PhoneClient { get; set; }
        public int TicketAmount { get; set; }
    
        public virtual Performance Performance { get; set; }
    }
}
