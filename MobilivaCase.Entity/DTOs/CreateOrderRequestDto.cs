using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Entity.DTOs
{
    public class CreateOrderRequestDto
    {
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Müşteri adı en az 2 en çok 30 karakter olmalıdır")]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength(11)]
        public string CustomerGSM { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }

    }
}
