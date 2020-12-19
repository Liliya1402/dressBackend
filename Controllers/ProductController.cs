using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dressBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly AppDbContext _dbc = new AppDbContext();

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _dbc.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _dbc.Products.Find(id);
        }

        [HttpPost]
        public void Post([FromBody] Product value)
        {
            int id = _dbc.Products.AsEnumerable().Last().Id + 1;

          Product pro = new Product { 
                Id = id,
                Name = value.Name,
                Price = value.Price,
                PhotoPath = value.PhotoPath,
              
            };

            _dbc.Products.Add(pro);
            _dbc.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            Product pro = _dbc.Products.Where(p => p.Id == id)
                                       .FirstOrDefault();

            if ( pro!= null)
            {
                pro.Name = value.Name;
                pro.Price = value.Price;
                pro.PhotoPath=value.PhotoPath;
             
                _dbc.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             Product pro = _dbc.Products.Find(id);
            _dbc.Products.Remove(pro);
            _dbc.SaveChanges();
        }
    }
}