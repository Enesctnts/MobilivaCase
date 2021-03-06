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
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        //İlişkiler

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }


       
    }
}
