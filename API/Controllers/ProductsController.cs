using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Data;
using API.Interfaces;
using API.Specifications;
using API.DTOS;
using System.Linq;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;
using API.Helpers;
using System.Text.Json;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductSizeRel> _productSizeRepo;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Size> _sizeRepo;
        private StoreContext _context; //////////// readonly
        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo,
        IMapper mapper, IGenericRepository<ProductSizeRel> productSizeRepo, IGenericRepository<Size> sizeRepo, IProductRepository productRepository, StoreContext context)
        {
            this._mapper = mapper;
            this._productRepo = productRepo;
            this._productBrandRepo = productBrandRepo;
            this._productTypeRepo = productTypeRepo;
            this._productRepository = productRepository;
            this._productSizeRepo = productSizeRepo;
            this._context = context;
            this._sizeRepo = sizeRepo;

        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesBrandsSizesSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);
            var products = await _productRepo.ListAsync(spec);

            var totalItems = await _productRepo.CountAsync(countSpec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));

            // return products.Select(product => new ProductToReturnDto 
            // {
            //        Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     Price = product.Price,
            //     PictureUrl = product.PictureUrl,
            //     ProductType = product.ProductType.Name,
            //     ProductBrand = product.ProductBrand.Name
            // })         .ToList();
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // neobavezno
        [ProducesResponseType(StatusCodes.Status404NotFound)] // neobavezno
        public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id)
        //  public async Task<List<SizeNoLoop>> GetProducts(int id)
    
        {
            var spec = new ProductsWithTypesBrandsSizesSpecification(id);

            var product = await _productRepo.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            var dto = _mapper.Map<Product, ProductToReturnDto>(product);

            

            dto.ProductSize = this.ReturnSize(id);

            return Ok(dto);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
       // [HttpGet("{id}")]
        // [ProducesResponseType(StatusCodes.Status200OK)] // neobavezno
        // [ProducesResponseType(StatusCodes.Status404NotFound)] // neobavezno
        public List<SizeNoLoop> ReturnSize(int id)
        {
            var size = new List<SizeNoLoop>();
            List<int> rel = this.Helper(id);
            foreach (var item in rel)
            {
                //size.Add( await _context.Set<Size>().FindAsync(item));
                size.Add(_context.Sizes.Where(x => x.Id == item).Select(x => new SizeNoLoop{
                    Id = x.Id,
                    Name = x.Name
                }).FirstOrDefault());
            }
            // foreach(var item in size){
            //     item.ProductSizes = null;
            // }
            return size;
        }
        public List<int> Helper (int id)
        {
            return (_context.ProductSizesRel.Where(x => x.ProductId == id).Select(x => x.SizeId).ToList());
        }
        // public Size Helper2 (int item)
        // {
        //     return 
        // }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }

           [HttpGet("sizes")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductSizes()
        {
            return Ok(await _productSizeRepo.ListAllAsync());
        }
        public async Task<ActionResult<IReadOnlyList<Size>>> GetSizeById(int id)
        {
            return Ok( await _sizeRepo.GetByIdAsync(id));
        }


        
    //     [HttpPost]
    //     public async Task<ActionResult<Product>> CreateProduct()
    //     {
    //         return Ok(await _productRepository.CreateProductAsync());
    //     }
     }

}