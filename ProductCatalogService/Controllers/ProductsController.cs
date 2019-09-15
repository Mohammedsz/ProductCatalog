using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProductCatalogDataAccess.Models;
using ProductCatalogDataAccess.Dtos;
using AutoMapper;

namespace ProductCatalogService.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductCatalogEntities _db;

        public ProductsController()
        {
            _db = new ProductCatalogEntities();
        }
        // GET: http://localhost:54891/api/Products
        public IHttpActionResult GetProducts()
        {
            //var productsDto = _db.Products.ToList().Select(s => new { ProductId = s.ProductId, ProductName = s.ProductName, UnitPrice=s.UnitPrice, UnitsInStock =s.UnitsInStock, SupplierName = s.Supplier.SupplierName});
            var productsDto = _db.Products.Include(p => p.Supplier).ToList().Select(Mapper.Map<Product, ProductDto>);
            return Ok(productsDto);
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = Mapper.Map<Product,ProductDto>(product);
            return Ok(productDto);
        }

        // PUT: api/Products/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDto.ProductId)
            {
                return BadRequest();
            }

            var productInDb = _db.Products.SingleOrDefault(p => p.ProductId ==id);

            Mapper.Map(productDto, productInDb);
            try
            {
                _db.SaveChanges();
                productDto.ProductId = productInDb.ProductId;
                return Created(new Uri(Request.RequestUri + "/" + productInDb.ProductId), productDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [HttpPost]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = Mapper.Map<ProductDto, Product>(productDto);

            _db.Products.Add(product);
            _db.SaveChanges();
            productDto.ProductId = product.ProductId;
            return CreatedAtRoute("DefaultApi", new { id = productDto.ProductId }, productDto);
        }

        // DELETE: api/Products/5
        [HttpDelete]
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);
            _db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return _db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}