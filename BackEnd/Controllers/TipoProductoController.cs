using Microsoft.AspNetCore.Mvc;
using SistemaABC.Models;
using SistemaABC.Services;
using System;
using System.Threading.Tasks;

namespace SistemaABC.Controllers
{
  [Route("api/tiposproductos")]
  [ApiController]
  public class TiposProductosController : ControllerBase
  {
    private readonly ITiposProductos _tiposProductosService;

    public TiposProductosController(ITiposProductos tiposProductosService)
    {
      _tiposProductosService = tiposProductosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var tiposProductos = await _tiposProductosService.getList();
      return Ok(tiposProductos);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TiposProducto tiposProducto)
    {
      var tiposProductoNuevo = await _tiposProductosService.add(tiposProducto);
      return CreatedAtAction(nameof(Get), new { id = tiposProductoNuevo.Id }, tiposProductoNuevo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

      var producto = await _tiposProductosService.getByID(id);
      if (!producto.EsValido)
      {
        return NotFound(producto);
      }

      var result = await _tiposProductosService.delete(id);
      if (!result.EsValido)
      {
        return NotFound(result.Mensaje);
      }

      return Ok(result);
    }
  }
}

