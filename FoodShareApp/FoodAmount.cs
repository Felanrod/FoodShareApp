namespace FoodShareApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FoodAmount
    {
        public int FoodAmountId { get; set; }

        [Column("FoodAmount")]
        [Required]
        [StringLength(50)]
        public string FoodAmount1 { get; set; }
    }
}
