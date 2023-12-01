namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Turnos
    {
        [Key]
        public int ID_TURNO { get; set; }

        public int ID_CLIENTE { get; set; }

        public int ID_PELUQUERO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_REGISTRO { get; set; }

        public TimeSpan HORA { get; set; }

        [Required]
        [StringLength(50)]
        public string ESTADO { get; set; }

        [Required]
        [StringLength(50)]
        public string SERVICIO { get; set; }



        [Column(TypeName = "date")]
        public DateTime DIA_TURNO { get; set; }

    }
}