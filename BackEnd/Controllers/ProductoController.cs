using Microsoft.AspNetCore.Mvc;
using SistemaABC.Models;
using SistemaABC.Services;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SistemaABC.Controllers
{
  [Route("api/productos")]
  [ApiController]
  public class ProductoController : ControllerBase
  {
    private readonly IProducto _productoService;

    public ProductoController(IProducto productoService)
    {
      _productoService = productoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var productos = await _productoService.getList();
      return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var producto = await _productoService.getByID(id);
      if (producto == null)
      {
        return NotFound();
      }
      return Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Producto producto)
    {
      var productoNuevo = await _productoService.add(producto);
      return CreatedAtAction(nameof(Get), new { id = productoNuevo.Id }, productoNuevo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
    {

      var resultado = await _productoService.update(id, producto);

      if (resultado.EsValido)
      {
        return Ok(resultado);
      }
      else
      {
        return BadRequest("Error al actualizar el producto." + resultado.Mensaje);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      
      var producto = await _productoService.getByID(id);
      if (!producto.EsValido)
      {
        return NotFound(producto);
      }
      
      var result = await _productoService.delete(id);
      if (!result.EsValido)
      {
        return NotFound(result.Mensaje);
      }

      return Ok(result);
    }
  }
}

