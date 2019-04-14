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

        [Display(Name = "Type")]
        public int TypeId { get; set; }

        [Display(Name = "To")]
        public string ToId { get; set; }

        [Display(Name = "From")]
        public string FromId { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public bool Viewed { get; set; }

        [Display(Name = "Date")]
        public DateTime? DateCreated { get; set; }

        public virtual NotificationType NotificationType { get; set; }
    }
}
