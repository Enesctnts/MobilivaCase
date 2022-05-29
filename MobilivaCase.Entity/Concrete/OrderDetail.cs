using MobilivaCase.Core.Entities;
using MobilivaCase.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Entity.Concrete
{
    [Table("OrderDetails")]
    public class OrderDetail : IEntity
    {

        [Key]
        public string Id { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductId { get; set; }
        public string OrderId { get; set; }

        //İlişkiler

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }


        //Conctucter'da ilk değer ataması
        public OrderDetail()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
