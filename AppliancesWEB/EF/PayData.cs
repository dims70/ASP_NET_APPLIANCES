namespace AppliancesWEB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayData")]
    public partial class PayData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idUser { get; set; }

        [Required]
        [StringLength(20)]
        public string NumberCard { get; set; }

        [Required]
        [StringLength(20)]
        public string Holder { get; set; }

        [Required]
        [StringLength(5)]
        public string DateEnd { get; set; }

        [Required]
        [StringLength(3)]
        public string CVC { get; set; }

        public virtual DataUsers DataUsers { get; set; }
    }
}
