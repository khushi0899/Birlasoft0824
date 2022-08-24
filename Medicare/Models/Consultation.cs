using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Medicare.Models
{
    [Table(name: "Consultation")]
    public class Consultation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultationId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Required]
        [StringLength(10)]
        [MinLength(10,ErrorMessage ="{0} is required minimum 10 digits")]
        [MaxLength(10,ErrorMessage ="{0} is required maxmum 10 digits")]
        [Column(TypeName ="varchar(10)")]
        [Display(Name ="Mobile Number")]

        public string MobileNo { get; set; }

        [Required(ErrorMessage = "{0} please Confirm!")]
        [Display(Name = "Consultation Status")]
        public bool ConsultationStatus { get; set; }

        public const int ConsultationPrice = 499;

        // public string UserId { get; set; }
        //foregin relationship
        public DateTime OrderDateTime { get; set; }
        public int DrId { get; set; }

        [ForeignKey(nameof(Consultation.DrId))]
        public DrList DrList { get; set; }


    }
}
