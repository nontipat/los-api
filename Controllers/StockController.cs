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
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;
        public static readonly List<StockList> _stock = new List<StockList>();

        public StockController(ILogger<StockController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<StockList> Get()
        {
            return _stock;
        }

        [HttpPost]
        public List<StockList> create(StockList stock)
        {
            _stock.Add(stock);
            return _stock;
        }

        [Route("{id}")]
        [HttpGet]
        public ObjectResult GetId(string id)
        {
            var _obj = _stock.Where(model => model.id == id).ToList();
            return Ok(_obj);
        }

        [Route("{id}")]
        [HttpPut]
        public List<StockList> update(string id, StockList stock)
        {
            var obj = _stock.FirstOrDefault(model => model.id == id);
            if (obj != null) {
                obj.productId = stock.productId;
                obj.amount = stock.amount;
            }
            return _stock;
        }

        [Route("{id}")]
        [HttpDelete]
        public List<StockList> delete(string id)
        {
             _stock.RemoveAll(model => model.id == id);
            return _stock;
        }
    }
}
