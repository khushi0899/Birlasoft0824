using Medicare.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Medicare.Areas.DisplayData.ViewModels

{
    public class DisplayDataViewModel
    {
        [Required]
        [Display(Name = "Product Category")]
        public int ProductCategoryId { get; set; }   

        public ICollection<ProductCategories> ProductCategories { get; set; }

        public ICollection<Products> Products { get; set; }

        public int? Quantity { get; set; }
    }
}
