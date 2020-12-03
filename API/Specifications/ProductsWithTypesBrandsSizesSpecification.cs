using System;
using System.Linq.Expressions;
using API.Models;
using API.Specification;

namespace API.Specifications
{
    public class ProductsWithTypesBrandsSizesSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesBrandsSizesSpecification(ProductSpecParams productParams)
            : base(x => 
                    (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                    (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                    (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
           // AddInclude(x => x.ProductSizes);
            AddOrderBy(x => x.Name); // order by alfabet name
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if ( !string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAscending":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDescending":
                        AddOrderByDescending(p => p.Price);
                        break;
                        default:
                            AddOrderBy(n =>n.Name);
                            break;
                }
            }
        }

         public ProductsWithTypesBrandsSizesSpecification(int id)
             : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductSizes);
        }
    }
}
