using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioAdmin.Bll
{
    public partial class Order
    {
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        public DateTime ShippingDate { get; set; }
        [Column(TypeName = "varchar(512)")]
        public string Comment { get; set; }
        [Column(TypeName = "int(11)")]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "int(11)")]
        public int CustomerId { get; set; }
        [Column(TypeName = "int(11)")]
        public int ShippingMethodId { get; set; }
        [Column(TypeName = "int(11)")]
        public int StatusId { get; set; }

        [MySqlCharset("latin1")]
        [NotMapped]
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [NotMapped]
        [ForeignKey("ShippingMethodId")]
        public ShippingMethod ShippingMethod { get; set; }

        [NotMapped]
        [ForeignKey("StatusId")]
        public OrderStatus Status { get; set; }
    }
}
