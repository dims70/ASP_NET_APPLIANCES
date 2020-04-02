namespace AppliancesWEB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Callback")]
    public partial class Callback
    {
        [Key]
        public int idQuestion { get; set; }

        public int idUser { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public virtual AuthUsers AuthUsers { get; set; }
        public Callback(int iduser, string description)
        {
            idUser = iduser;
            Description = description;
        }
    }
}
