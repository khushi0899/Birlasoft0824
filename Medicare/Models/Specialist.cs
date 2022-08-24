using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Text.Json.Serialization;
using Medicare.Models;

namespace Medicare.Models
{
    [Table(name: "Specialist")]
    public class Specialist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecialityId { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Specilist Category Name ")]
        public string SpecialityName { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(250)]
        [Column(TypeName = "varchar(250)")]
        [Display(Name = "Specialities Description")]
        public string SpecialityDescription { get; set; }


        //Shared Keys between Specialist and Drlist
        public ICollection<DrList> DrLists { get; set; }

        ////ForeginKey relationship
        //[Display(Name = "City")]
        //public virtual int CityId { get; set; }

        //[JsonIgnore]
        //[ForeignKey(nameof(Specialist.CityId))]
        //public DrCity DrCity { get; set; }



    }
}
