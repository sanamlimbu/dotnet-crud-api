using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet_crud_api.Entities;
using dotnet_crud_api.Models;

namespace dotnet_crud_api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ProductsController : ControllerBase
    {
        private readonly DbHelper _db;

        public ProductsController(DotNetCrudApiContext context)
        {
            _db = new DbHelper(context);
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult  Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<ProductModel> data = _db.GetProducts();
                if (!data.Any()) {
                    type = ResponseType.NotFound;  
                }
                return Ok(HTTPResponseHandler.GetHTTPResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(HTTPResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                ProductModel data = _db.GetProductById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(HTTPResponseHandler.GetHTTPResponse(type, data));
            }
            catch(Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(HTTPResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] ProductModel product) 
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.CreateProduct(product);
                return Ok(HTTPResponseHandler.GetHTTPResponse(type, product));
            }
            catch(Exception ex)
            {
                return BadRequest(HTTPResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ProductModel product)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateProduct(id, product);
                return Ok(HTTPResponseHandler.GetHTTPResponse(type, product));
            }
            catch (Exception ex)
            {
                return BadRequest(HTTPResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteProduct(id);
                return Ok(HTTPResponseHandler.GetHTTPResponse(type, "Deleted successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(HTTPResponseHandler.GetExceptionResponse(ex));
            }

        }
    }
}
