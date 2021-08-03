using DotNetCoreWebApiThree.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreWebApiThree.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        public ProductsController(ProductsService products, ProductsService id)
        {
            Products = products;
            Id = id;
        }

        public ProductsService Products { get; }
        public ProductsService Id { get; }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Products.GetProducts());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{Id}")]
        public IActionResult Get(string Id)
        {
            //return Ok(Products.GetProductById(Id));
            return Ok(Products.GetProducts().First(x => x.Id == Id));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
