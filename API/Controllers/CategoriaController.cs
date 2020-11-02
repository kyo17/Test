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
    public class CategoriaController : Controller
    {
        private ICategoria db = new CategoriaCollection();

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok(await db.getAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getOne(string id)
        {
            return Ok(await db.getOne(id));
        }

        [HttpPost]
        public async Task<IActionResult> insertOne([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }
            await db.addCategoria(categoria);
            return Created("Agregado con exito", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateOne([FromBody] Categoria categoria, string id)
        {
            categoria.id = id;
            await db.updateCategoria(categoria);
            return Created("Modificado", true);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteOne(string id)
        {
            await db.deleteCategoria(id);
            return NoContent();
        }
    }
    
}
