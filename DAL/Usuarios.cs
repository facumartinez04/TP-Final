namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [Key]
        [StringLength(50)]
        public string usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string contraseña { get; set; }
    }
}
