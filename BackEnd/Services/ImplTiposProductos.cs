using Microsoft.EntityFrameworkCore;
using SistemaABC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaABC.Services
{
  public class ImplTiposProductos : ITiposProductos
  {
    private readonly DbpruebaTecnicaAngelContext _context;

    public ImplTiposProductos(DbpruebaTecnicaAngelContext context)
    {
      _context = context;
    }

    public async Task<Result<List<TiposProducto>>> getList()
    {
      var tiposProductos = await _context.TiposProductos.Where(tipoProducto => tipoProducto.Status != 0).ToListAsync();

      // Crear una instancia de Result y configurarla según la respuesta.
      var result = new Result<List<TiposProducto>>();

      if (tiposProductos != null && tiposProductos.Any())
      {
        result.Id = 1;
        result.Mensaje = "Tipos de productos encontrados.";
        result.Datos = tiposProductos;
        result.EsValido = true;
      }
      else
      {
        result.Id = 0;
        result.Mensaje = "No se encontraron tipos de productos.";
        result.Datos = null;
        result.EsValido = false;
      }

      return result;
    }


    public async Task<Result<TiposProducto>> add(TiposProducto tipoProducto)
    {
      Result<TiposProducto> result = new Result<TiposProducto>();
      try
      {
        _context.TiposProductos.Add(tipoProducto);
        await _context.SaveChangesAsync();

        result.Id = 1;
        result.Mensaje = "Producto agregado exitosamente.";
        result.EsValido = true;
        result.Datos = tipoProducto;
      }
      catch (Exception ex)
      {
        // Manejo de errores en caso de excepción
        result.Id = 0;
        result.Mensaje = "Error al agregar el Tipo Producto: " + ex.Message;
        result.EsValido = false;
        result.Datos = null; // Opcional: Puedes definir cómo manejar los datos en caso de error.
      }
      return result;
    }


    public async Task<Result<bool>> delete(int id)
    {
      Result<bool> result = new Result<bool>();
      try
      {
        _context.Database.ExecuteSqlInterpolated($@"EXEC DeleteTipoProducto @TipoProductoID = {id}");

        result.Id = 1;
        result.Mensaje = "Tipo Producto eliminado exitosamente.";
        result.EsValido = true;
        result.Datos = true;
      }
      catch (Exception ex)
      {
        // Manejo de errores en caso de excepción
        result.Id = 0;
        result.Mensaje = "Error al eliminar el Tipo Producto: " + ex.Message;
        result.EsValido = false;
        result.Datos = false;
      }
      return result;
    }


    public async Task<Result<TiposProducto>> getByID(int id)
    {
      Result<TiposProducto> result = new Result<TiposProducto>();
      try
      {
        var tiposProducto = await _context.TiposProductos.FindAsync(id);
        if (tiposProducto != null)
        {
          result.Id = 1;
          result.Mensaje = "Tipo Producto encontrado.";
          result.EsValido = true;
          result.Datos = tiposProducto;
        }
        else
        {
          result.Id = 0;
          result.Mensaje = "Tipo Producto no encontrado.";
          result.EsValido = false;
          result.Datos = null;
        }
      }
      catch (Exception ex)
      {
        result.Id = 0;
        result.Mensaje = "Error al obtener el Tipo Producto: " + ex.Message;
        result.EsValido = false;
        result.Datos = null;
      }
      return result;
    }
  }
}

