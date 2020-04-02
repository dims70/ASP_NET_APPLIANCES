namespace AppliancesWEB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListSupply")]
    public partial class ListSupply
    {
        [Key]
        public int idSupply { get; set; }

        public int idSupplier { get; set; }

        public int idEquipment { get; set; }

        public int Number { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public virtual Equipments Equipments { get; set; }

        public virtual Suppliers Suppliers { get; set; }
    }
}
