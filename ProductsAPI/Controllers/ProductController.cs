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
            var response = productbusiness.GetAllProducts();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.Response);
            }
            else
                return StatusCode((int)response.StatusCode, response.Message);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult GetProductDetails(string id)
        {
            var response = productbusiness.GetProductDetails(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.Response);
            }
            else
                return StatusCode((int)response.StatusCode, response.Message);
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
