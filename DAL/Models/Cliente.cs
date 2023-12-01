namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [Key]
        public int ID_CLIENTE { get; set; }

        [Required]
        [StringLength(120)]
        public string NOMBRE_APELLIDO { get; set; }

        [Required]
        [StringLength(50)]
        public string TELEFONO { get; set; }


        [StringLength(50)]
        public string usuario { get; set; }


        [StringLength(50)]
        public string contraseña { get; set; }


        [StringLength(50)]
        public string estado { get; set; }
    }
}