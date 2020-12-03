using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public ProductRepository(StoreContext context, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._context = context;
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .Include(r=>r.ProductSizes).ThenInclude(r => r.SizeId)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductSizes).ThenInclude(d => d.SizeId)
                .ToListAsync();
        }



        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductSizeRel>> GetProductSizesRelAsync()
        {
            return await _context.ProductSizesRel.ToListAsync();
        }

        // public async Task<Product> CreateProductAsync()
        // {
        //     int typeId = 1;
        //     int brandId = 2;
        //     List<int> sizeId = new List<int>() { 1, 2 };
        //     List<ProductSize> productSize = new List<ProductSize>();
        //     var productType = _context.ProductTypes.FindAsync(typeId).Result;
        //     var productBrand = _context.ProductBrands.FindAsync(brandId).Result;
        //     foreach (var item in sizeId)
        //     {
        //         productSize.Add(_context.ProductSizes.FindAsync(item).Result);
        //     }



        //     var product = new Product{
        //         Name = "U bre",
        //         Description = "Na vr olele da jedem",
        //         Price = 2000,
        //         PictureUrl = "images/products/shop1.png",
        //         ProductType = productType,
        //         ProductTypeId = typeId,
        //         ProductBrand = productBrand,
        //         ProductBrandId = brandId,
        //         ProductSize = productSize,
        //     };
            
        //     _unitOfWork.Repository<Product>().Add(product);

        //     //    TODO :save to db
        //     var result = await _unitOfWork.Complete();

        //     if (result <= 0) return null;

        //     return product;
        // }
    }
}