using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ProductSizeRel: BaseEntity
    {
                [Column(Order = 1)]
                public int ProductId { get; set; }
                [Column(Order = 2)]
                public int SizeId { get; set; }
                public Product Product {get; set;}
                public Size Size { get; set; }
                
    }
}