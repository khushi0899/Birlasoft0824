using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace Medicare.Models
{
    [Table(name: "DrList")]
    public class DrList
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrId { get; set; }



        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Dr Name")]
        public string DrName { get; set; }



        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(250, ErrorMessage = "Qualification is not Empty ")]
        [Column(TypeName = "varchar(250)")]
        [Display(Name = "Dr Qualification")]
        public string DrQualification { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(250, ErrorMessage = "Specialities is not Empty")]
        [Column(TypeName = "varchar(250)")]
        [Display(Name = "Dr Specialities")]
        public string DrSpecialities { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(250, ErrorMessage = "Description is not Empty!")]
        [Column(TypeName = "varchar(250)")]
        [Display(Name = "Dr Description")]
        public string DrDescription { get; set; }


        //[Required(ErrorMessage = "{0} cannot be empty!")]
        //[StringLength(50, ErrorMessage ="{0} cannot be Empty")]
        //[Column(TypeName = "varchar(250)")]
        //[Display(Name = "Clinic City")]
        // public string ClinicCity { get; set; }



        ////Foregin Key Relationship

        [Display(Name = "Clinic City  ")]
        public virtual int ClinicCity { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(DrList.ClinicCity))]
        public DrCity DrCity { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(250)")]
        [StringLength(250)]
        [Display(Name = "Clinic Adress")]
        public string ClinicAddress { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        [StringLength(10)]
        [MinLength(10,ErrorMessage ="{0} length should not be less then 10 Digits")]
        [MaxLength(10,ErrorMessage ="{0} length should not be greater then 10 Digits")]
        [Display(Name ="Mobile")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(250)")]
        [StringLength(250)]
        [Display(Name = "Availability")]
        public string  DrAvailability { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Fee")]
        public int DrFee { get; set; }

        [Display(Name = "Dr Photo")]
        [StringLength(500)]
        public virtual string ImageUrl { get; set; } = null;

        //Foregin Key Relationship

        [Display(Name = "  Dr Specialist  ")]
        public virtual int SpecialistId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(DrList.SpecialistId))]
        public Specialist Specialist { get; set; }
      


    }
}
