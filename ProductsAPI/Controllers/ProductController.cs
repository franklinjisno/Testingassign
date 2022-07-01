using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Business;
using ProductsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness productbusiness;

        public ProductController(IProductBusiness productbusiness)
        {
            this.productbusiness = productbusiness;
        }


    
        // POST api/<ProductController>
        [HttpPost]
        public IActionResult AddProduct(ProductDetails product)
        {
            var response = productbusiness.AddProduct(product);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.Response);
            }
            return StatusCode((int)response.StatusCode, response.Message);
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = productbusiness.GetAllProducts();
            if (products != null)
            {
                return Ok(products);
            }
            else
                return NotFound();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult GetProductDetails(string id)
        {
            var product = productbusiness.GetProductDetails(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
                return NotFound("Product Not Found");
        }


        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string id)
        {
            var response = productbusiness.DeleteProduct(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.Response);
            }
            return StatusCode((int)response.StatusCode, response.Message);    
        }
    }
}
