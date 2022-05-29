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
    [Table("Orders")]
    public class Order : IEntity
    {
        [Key]
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }
        public decimal TotalAmount { get; set; }


        //Bu siparişin içeriğinde neler var? Ne almış?
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } //Navigation property.

        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
