namespace FoodShareApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public int EventId { get; set; }

        public string FoodProviderAdminId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(500)]
        public string EventName { get; set; }

        [Display(Name = "Date")]
        [Column(TypeName = "date")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Start Time")]
        public TimeSpan EventTime { get; set; }

        [Required]
        [StringLength(500)]
        public string Location { get; set; }

        [Display(Name = "Contact Number")]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        public string Notes { get; set; }
    }
}
