namespace AppliancesWEB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [Key]
        public int idOrder { get; set; }

        public int idUser { get; set; }

        public DateTime DateOrder { get; set; }

        public int idStatus { get; set; }

        public int idEquipment { get; set; }

        public int Number { get; set; }

        [Column(TypeName = "money")]
        public decimal Summary { get; set; }

        public virtual AuthUsers AuthUsers { get; set; }

        public virtual Equipments Equipments { get; set; }

        public virtual Statuses Statuses { get; set; }
    }
}
