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
        [StringLength(100)]
        public string FoodName { get; set; }

        public string FoodProviderId { get; set; }

        public int FoodTypeId { get; set; }

        public int FoodAmountId { get; set; }

        public bool? Urgent { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual FoodType FoodType { get; set; }
    }
}
