using Medicare.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Medicare.Areas.DisplayData.ViewModels
{
    public class SearchDrViewModel
    {
        [Required]
        [Display(Name = "Product Category")]
        public int CityId { get; set; }



        public ICollection<DrList>DrList { get; set; }


        //public ICollection<DrCity> DrCity { get; set; }

        //public string? Specialist { get; set; }

        //public string? SearchString { get; set; }

    }
}
