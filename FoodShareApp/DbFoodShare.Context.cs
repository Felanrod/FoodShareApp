﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodShareApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DefaultConnection : DbContext
    {
        public DefaultConnection()
            : base("name=DefaultConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<FoodAmount> FoodAmounts { get; set; }
        public virtual DbSet<FoodHour> FoodHours { get; set; }
        public virtual DbSet<FoodProvider> FoodProviders { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationType> NotificationTypes { get; set; }
        public virtual DbSet<Requester> Requesters { get; set; }
        public virtual DbSet<FoodType> FoodTypes { get; set; }
    }
}
