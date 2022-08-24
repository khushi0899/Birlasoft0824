using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Text.Json.Serialization;

namespace Medicare.Models
{
    [Table(name:"ProductCategories")]
    public class ProductCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductCategoryId { get; set; }


        [Required]
        [StringLength(100)]
        [Column(TypeName ="varchar(100)")]
        [Display(Name ="Product Category Name ")]
        public string ProductCategoryName { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(250)]
        [Column(TypeName = "varchar(250)")]
        [Display(Name = "Product Category Description")]
        public string ProductCategoryDescription { get; set; } 

        //Define relations betweeen ProductCategories and Products
        public ICollection<Products> Products { get; set; }
    }
}
