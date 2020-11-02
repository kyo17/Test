using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private IProducto db = new ProductoCollection();

        [HttpGet]
        public async Task<IActionResult> getProducts()
        {
            return Ok(await db.getProductos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getProduct(string id)
        {
            return Ok(await db.getProductoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> insertProducto([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }

            await db.addProducto(producto);
            
            return Created("Agregado con exito", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateProducto([FromBody] Producto producto, string id)
        {

            producto.id = id;
            await db.updateProducto(producto);
            return Created("Modificado", true);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteProducto(string id)
        {
            await db.deleteProducto(id);
            return NoContent();
        }
    }
}
