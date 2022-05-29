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
    [Table("Products")]
    public class Product : IEntity
    {

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public decimal UnitPrice { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Unit { get; set; }
        public bool Status { get; set; }


        //İlişkiler
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
