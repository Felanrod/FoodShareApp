namespace FoodShareApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FoodProviderType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FoodProviderType()
        {
            FoodProviders = new HashSet<FoodProvider>();
        }

        [Key]
        public int ProviderTypeId { get; set; }

        [Column("ProviderType")]
        [Required]
        [StringLength(50)]
        public string ProviderType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FoodProvider> FoodProviders { get; set; }
    }
}
