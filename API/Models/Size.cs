using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace API.Models
{
    public class Size : BaseEntity
    {
        
                public string Name { get; set; }
                [JsonIgnoreAttribute]
                public IList<ProductSizeRel> ProductSizes {get; set;}
    }
}