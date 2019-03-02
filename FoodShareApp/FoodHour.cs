namespace FoodShareApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FoodHour
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FoodHourId { get; set; }

        public int FoodProviderId { get; set; }

        public int? OpenHourMo { get; set; }

        public int? CloseHourMo { get; set; }

        public int? OpenHourTu { get; set; }

        public int? CloseHourTu { get; set; }

        public int? OpenHourWe { get; set; }

        public int? CloseHourWe { get; set; }

        public int? OpenHourTh { get; set; }

        public int? CloseHourTh { get; set; }

        public int? OpenHourFr { get; set; }

        public int? CloseHourFr { get; set; }

        public int? OpenHourSa { get; set; }

        public int? CloseHourSa { get; set; }

        public int? OpenHourSu { get; set; }

        public int? CloseHourSu { get; set; }

        public string Notes { get; set; }

        public virtual FoodProvider FoodProvider { get; set; }
    }
}
