using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioAdmin.Bll
{
    public partial class ShippingMethod
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(1024)")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal? Price { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
    }
}
