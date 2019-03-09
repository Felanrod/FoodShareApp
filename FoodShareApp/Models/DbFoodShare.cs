namespace FoodShareApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbFoodShare : DbContext
    {
        public DbFoodShare()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<FoodAmount> FoodAmounts { get; set; }
        public virtual DbSet<FoodHour> FoodHours { get; set; }
        public virtual DbSet<FoodProvider> FoodProviders { get; set; }
        public virtual DbSet<FoodProviderType> FoodProviderTypes { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<FoodType> FoodTypes { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationType> NotificationTypes { get; set; }
        public virtual DbSet<Requester> Requesters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<FoodProvider>()
                .Property(e => e.PostalCode)
                .IsFixedLength();

            modelBuilder.Entity<FoodProvider>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<FoodProvider>()
                .HasMany(e => e.FoodHours)
                .WithRequired(e => e.FoodProvider)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodProviderType>()
                .HasMany(e => e.FoodProviders)
                .WithRequired(e => e.ProviderType)
                .HasForeignKey(e => e.FoodProviderTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodType>()
                .HasMany(e => e.Foods)
                .WithRequired(e => e.FoodType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NotificationType>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.NotificationType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Requester>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Requester>()
                .Property(e => e.PostalCode)
                .IsFixedLength();
        }
    }
}
