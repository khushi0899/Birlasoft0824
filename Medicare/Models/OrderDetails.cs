using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medicare.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }


        [Required]
        public int Quantity { get; set; }


        #region Navigation Properties to Order Model

        [Required]
        public int OrderNumber { get; set; }


        [ForeignKey(nameof(OrderDetail.OrderNumber))]
        public Order Order { get; set; }

        #endregion


        #region Navigation Properties to Products Model 

        [Required]
        public int ProductId { get; set; }


        [ForeignKey(nameof(OrderDetail.ProductId))]
        public Products Products { get; set; }

        #endregion

    }
 }
