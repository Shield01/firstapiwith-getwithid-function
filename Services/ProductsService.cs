using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using DotNetCoreWebApiThree.Models;

namespace DotNetCoreWebApiThree.Services
{
    public class ProductsService
    {
        public ProductsService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public string DbContent
        {
            get 
            { 
                return  Path.Combine(WebHostEnvironment.ContentRootPath, "data", "productsdb.json");
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var ReadDb = File.OpenText(DbContent))
            {
                return JsonSerializer.Deserialize<Product[]>(ReadDb.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                    );
            }
            
        }

        //public IEnumerable<Product> QueryById(string productId)
        //{
        //    var ReadDb = File.OpenText(DbContent)
            
        //    using(var queryById = GetProducts().First(x => x.Id == productId))
        //    {
        //        return JsonSerializer.Deserialize<Product>(ReadDb.ToEnd());
        //    }
            
        //}

        //public void GetProductById(string id)
        //{
        //    GetProducts().First(x => x.Id == Id);
        //}
    }
}
