﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clown.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Shigapov326CircusEntities : DbContext
    {
        public Shigapov326CircusEntities()
            : base("name=Shigapov326CircusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<AnimalType> AnimalType { get; set; }
        public virtual DbSet<Cage> Cage { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemEmployee> ItemEmployee { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<SchedulePerformance> SchedulePerformance { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TicketSale> TicketSale { get; set; }
    }
}
