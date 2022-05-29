using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Entity.DTOs
{
    public class ProductDto
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Ürün açıklaması en az 2 en çok 100 karakter olmalıdır!")]
        public string Description { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Ürünün kategorisi en az 2 en çok 20 karakter olmalıdır")]
        public string Category { get; set; }
        public int Unit { get; set; }

        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

    }

}
