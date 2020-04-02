namespace AppliancesWEB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Suppliers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Suppliers()
        {
            ListSupply = new HashSet<ListSupply>();
        }

        [Key]
        public int idSupplier { get; set; }

        public int idSupplyEquip { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int idContract { get; set; }

        public virtual Contracts Contracts { get; set; }

        public virtual Equipments Equipments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListSupply> ListSupply { get; set; }
    }
}
