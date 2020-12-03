using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioAdmin.Bll
{
    public partial class OrderStatus
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(1024)")]
        public string Description { get; set; }
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
    }
}
