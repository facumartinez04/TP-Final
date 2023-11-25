namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Peluquero")]
    public partial class Peluquero
    {
        [Key]
        public int ID_PELUQUERO { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE_APELLIDO { get; set; }

        [Required]
        [StringLength(50)]
        public string TELEFONO { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        public DateTime FECHA_INGRESO { get; set; }
    }
}
