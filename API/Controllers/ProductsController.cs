using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext context;
        public ProductsController(StoreContext context)
        {
            this.context = context;
            
        }
       [HttpGet]
       public async Task<ActionResult<List<Product>>> GetProducts()
       {
        var products = await context.Products.ToListAsync(); 
        return products;
       }

        [HttpGet("{id}")]
       public async Task<ActionResult<Product>> GetProduct(int id)
       {
        return await context.Products.FindAsync(id);
       }
    }
}