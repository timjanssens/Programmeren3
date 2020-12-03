using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioAdmin.Bll
{
    public partial class Book
    {
        [Column("ImageURL", TypeName = "varchar(255)")]
        public string ImageUrl { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Author { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Subtitle { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string PublicationDate { get; set; }
        [Column(TypeName = "varchar(120)")]
        public string Publisher { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Category { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Size { get; set; }
        [Column(TypeName = "varchar(6)")]
        public string NumberOfPages { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Language { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ProductCode { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ProductType { get; set; }
        [Column(TypeName = "varchar(80)")]
        public string ProductTypeFull { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string Description { get; set; }
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
    }
}
