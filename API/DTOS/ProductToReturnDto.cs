using System.Collections.Generic;
using API.Models;

namespace API.DTOS
{
    public class ProductToReturnDto
        {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Description { get; set; }
                public decimal Price { get; set; }
                public string  PictureUrl { get; set; }
                public string ProductType { get; set; }
                public string ProductBrand { get; set; }
                public List<SizeNoLoop> ProductSize { get; set; }
   
    }
}