using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Text.Json.Serialization;
namespace Medicare.Models
{
    [Table(name: "Products")]
    public class Products
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }



        [Required(ErrorMessage ="{0} cannot be empty!")]
        [Column(TypeName ="int")]
        [Display(Name ="Product Price")]
        public int Price { get; set; }


        [Display(Name = "Product Image")]
        [StringLength(1000)]
        public virtual string ImageUrl { get; set; } = null;

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(100)]
        [Column(TypeName = "varchar(300)")]
        [Display(Name = "Highligts")]
        public string Highlights { get; set; }



        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(250)]
        [MinLength(10, ErrorMessage = "{0} length should not be less then 10 Digits")]
        [MaxLength(250, ErrorMessage = "{0} length should not be greater then 250 Digits")]
        [Column(TypeName = "varchar(250)")]
        [Display(Name = "Description")]
        public string ProductDescription { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(200)]
        [MinLength(10, ErrorMessage = "{0} length should not be less then 10 Digits")]
        [MaxLength(200, ErrorMessage = "{0} length should not be greater then 200 Digits")]
        [Column(TypeName = "varchar(300)")]
        [Display(Name = "Benefits")]
        public string Benefits { get; set; }



        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(100)]
        [Column(TypeName = "varchar(200)")]
        [Display(Name = "Ingrediants")]
        public string Ingrediants { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(200)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Direct To Use")]
        public string DirectToUSe { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(200)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Precaution")]
        public string Precaution { get; set; }


        //Foregin Key Relationship

        [Display(Name ="Product Category")]
        public virtual int ProductCategoryId { get; set; }

        
        [ForeignKey(nameof(Products.ProductCategoryId))]
        public ProductCategories ProductCategories { get; set; }
    }
}
