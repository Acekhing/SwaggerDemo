using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]  
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Gets a product given a product Id
        /// </summary>
        /// <returns>Product.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        /// GET  /Product/1
        /// 
        /// </remarks>
        /// <response code="200">Returns the product object</response>
        /// <response code="404">Returns NotFound</response>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductById(int Id)
        {

            var product = Products().Find(p => p.Id == Id);

            if (product == null) 
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(product);
        }

        /// <summary>
        /// Creates a new Product
        /// </summary>
        /// <returns>Product.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        /// POST  /Product
        ///     {
        ///         id: int,
        ///         name: string,
        ///         price: double
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Product created</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductModel productModel)
        {
            if (productModel == null)
            {
                return new BadRequestResult();
            }

            Products().Add(productModel);
            return CreatedAtAction(nameof(GetProducts), new { Id = productModel.Id, version = "1.0" }, productModel);
        }


        /// <summary>
        /// Gets the list of all Products.
        /// </summary>
        /// <returns>The list of Products.</returns>
        /// GET: api/Product
        [HttpGet]
        public IActionResult GetProducts()
        {
           var products = Products();
            return new OkObjectResult(products);
        }
        private List<ProductModel> Products()
        {
            return new List<ProductModel>()
        {
            new ProductModel()
            {
                Id = 1,
                Name = "Bag",
                Price = 56.99
            },
            new ProductModel()
            {
                Id = 2,
                Name = "Shoe",
                Price = 199.9
            }
        };
        }
    }
}
