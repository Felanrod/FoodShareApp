namespace FoodShareApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        public int NotificationId { get; set; }

        public int TypeId { get; set; }

        public int ToId { get; set; }

        public int FromId { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        public bool Viewed { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual NotificationType NotificationType { get; set; }
    }
}
