using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapProject.Contracts.Requests;
using AutoMapProject.Contracts.Responses;
using AutoMapProject.Domain;
using AutoMapProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapProject.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetProductsAsync();
            var productsResponse = _mapper.Map<List<ProductResponse>>(products);
            return Ok(productsResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData([FromRoute] int productId)
        {
            var product = await _productService.GetProductAsync(productId);

            if (product == null) return NotFound("No record found");

            var productResponse = _mapper.Map<List<ProductResponse>>(product);
            return Ok(productResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest createProductRequest)
        {
            var product = new Product
            {
                ProductName = createProductRequest.ProductName
            };
            await _productService.CreateProductAsync(product);
            var productResponse = _mapper.Map<ProductResponse>(product);
            var uri = "api/v1/products/" + product.ProductId;
            return Created(uri, productResponse);
        }
    }
}
