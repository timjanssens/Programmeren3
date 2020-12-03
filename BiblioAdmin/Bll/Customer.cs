using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioAdmin.Bll
{
    public partial class Customer
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string City { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string PostalCode { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Phone { get; set; }
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
    }
}
