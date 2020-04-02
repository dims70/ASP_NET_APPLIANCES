namespace AppliancesWEB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipments()
        {
            ListSupply = new HashSet<ListSupply>();
            Orders = new HashSet<Orders>();
            Suppliers = new HashSet<Suppliers>();
        }

        [Key]
        public int idEquipment { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int idCategory { get; set; }

        [Required]
        [StringLength(50)]
        public string Builder { get; set; }

        [Required]
        [StringLength(50)]
        public string StateEquipment { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string imageEquipmentPath { get; set; }

        public virtual Categories Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListSupply> ListSupply { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Suppliers> Suppliers { get; set; }
    }
}
