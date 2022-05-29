using System;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Entity.DTOs
{
    public class ProductDetail
    {
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
    }
}
