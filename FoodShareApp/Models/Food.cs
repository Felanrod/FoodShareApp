namespace FoodShareApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Food
    {
        public int FoodId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(100)]
        public string FoodName { get; set; }

        public string FoodProviderId { get; set; }

        [Display(Name = "Type")]
        public int FoodTypeId { get; set; }

        [Display(Name = "Amount")]
        public int FoodAmountId { get; set; }

        public bool? Urgent { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Display(Name = "Date Posted")]
        public DateTime DateCreated { get; set; }

        public virtual FoodType FoodType { get; set; }
    }
}
