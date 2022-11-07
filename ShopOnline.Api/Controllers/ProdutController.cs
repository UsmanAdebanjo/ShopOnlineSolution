using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositiories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProdutController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetItem(id);

                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    var productCategory = await _productRepository.GetProductCategory(product.CategoryId);
                    ProductDto productDto = product.ConvertToDto(productCategory);
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProducts()
        {

            try
            {
                var products = await _productRepository.GetItems();
                var productCatgories = await _productRepository.GetProductCategories();

                if (products == null || productCatgories == null)
                {
                    return NotFound();
                }

                else
                {
                    var productDto = products.ConvertToDto(productCatgories);

                    return Ok(productDto);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "error retrieving data from database");
            }
        }

    }
}
