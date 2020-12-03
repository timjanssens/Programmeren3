using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioAdmin.Bll
{
    public partial class OrderItem
    {
        [Column(TypeName = "int(11)")]
        public int BookId { get; set; }
        [Column(TypeName = "int(11)")]
        public int OrderId { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? Quantity { get; set; }
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
    }
}
