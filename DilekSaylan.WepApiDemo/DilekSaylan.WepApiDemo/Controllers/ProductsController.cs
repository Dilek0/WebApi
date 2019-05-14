using DilekSaylan.WepApiDemo.DataAccess;
using DilekSaylan.WepApiDemo.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DilekSaylan.WepApiDemo.Controllers
{
    //make a route configuration for this class
    [Route("api/products")]
    public class ProductsController : Controller
    {
        IProductDal _productdal;

        public ProductsController(IProductDal productDal)
        {
            _productdal = productDal;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            var products = _productdal.GetList();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                var product = _productdal.Get(p => p.ProductId == productId);
                if (product == null)
                    return NotFound($"there is no product with Id = {productId}");
                return Ok(product);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }

        public IActionResult Post(Product product)
        {
            try
            {
                _productdal.Add(product);
                return new StatusCodeResult(201);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productdal.Update(product);
                return Ok(product);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                _productdal.Delete(new Product { ProductId = productId });
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }

        [HttpGet("GetProductsDetails")]
        public IActionResult GetProductsWithDetails()
        {
            try
            {
                var result = _productdal.GetProductsWithDetails();
                return Ok(result);

            }
            catch 
            {

            }
            return BadRequest();
        }
    }
}
