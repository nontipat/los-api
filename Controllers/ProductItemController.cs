using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using los_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace los_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductItemController : ControllerBase
    {
        private readonly ILogger<ProductItemController> _logger;

        public static readonly List<ProductItem> _products = new List<ProductItem>();

        public ProductItemController(ILogger<ProductItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<ProductItem> Get()
        {
            return _products;
        }

        [HttpPost]
        public List<ProductItem> create(ProductItem product)
        {
            _products.Add(product);
            return _products;
        }

        [Route("{id}")]
        [HttpGet]
        public ObjectResult GetId(string id)
        {
            var product_obj = _products.Where(model => model.id == id).ToList();
            return Ok(product_obj);
        }

        [Route("{id}")]
        [HttpPut]
        public List<ProductItem> update(string id, ProductItem product)
        {
            var obj = _products.FirstOrDefault(model => model.id == id);
            if (obj != null) {
                obj.name = product.name;
                obj.imageUrl = product.imageUrl;
                obj.price = product.price;
            }
            return _products;
        }

        [Route("{id}")]
        [HttpDelete]
        public List<ProductItem> delete(string id)
        {
            _products.RemoveAll(model => model.id == id);
            return _products;
        }
    }
}
