using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioAdmin.Bll
{
    public partial class Order
    {
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ShippingDate { get; set; }
        [Column(TypeName = "varchar(512)")]
        public string Comment { get; set; }
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Column(TypeName = "int(11)")]
        public int CustomerId { get; set; }
        [Column(TypeName = "int(11)")]
        public int ShippingMethodId { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        public int StatusId { get; set; }
    }
}
