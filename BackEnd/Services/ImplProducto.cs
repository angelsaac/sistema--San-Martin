
using Microsoft.EntityFrameworkCore;
using SistemaABC.Models;


namespace SistemaABC.Services
{
  public class ImplProducto : IProducto
  {
    private readonly DbpruebaTecnicaAngelContext _context;
    public ImplProducto(DbpruebaTecnicaAngelContext context)
    {
      _context = context;
    }

    public async Task<Result<List<Producto>>> getList()
    {
      Result<List<Producto>> result = new Result<List<Producto>>();
      try
      {
        result.Id = 1;
        result.Mensaje = "Se encontraron productos.";
        result.EsValido = true;
        result.Datos = await _context.Productos.Where(producto => producto.Status != 0).ToListAsync();
      }
      catch (Exception ex)
      {
        result.Id = 0;
        result.Mensaje = "Error al obtener productos: " + ex.Message;
        result.EsValido = false;
        result.Datos = null;
      }
      return result;
    }

    public async Task<Result<Producto>> getByID(int id)
    {
      Result<Producto> result = new Result<Producto>();
      try
      {
        var producto = await _context.Productos.FindAsync(id);
        if (producto != null)
        {
          result.Id = 1;
          result.Mensaje = "Producto encontrado.";
          result.EsValido = true;
          result.Datos = producto;
        }
        else
        {
          result.Id = 0;
          result.Mensaje = "Producto no encontrado.";
          result.EsValido = false;
          result.Datos = null; 
        }
      }
      catch (Exception ex)
      {
        result.Id = 0;
        result.Mensaje = "Error al obtener el producto: " + ex.Message;
        result.EsValido = false;
        result.Datos = null; 
      }
      return result;
    }


    public async Task<Result<Producto>> add(Producto producto)
    {
      Result<Producto> result = new Result<Producto>();
      try
      {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        result.Id = 1;
        result.Mensaje = "Producto agregado exitosamente.";
        result.EsValido = true;
        result.Datos = producto;
      }
      catch (Exception ex)
      {
        // Manejo de errores en caso de excepción
        result.Id = 0;
        result.Mensaje = "Error al agregar el producto: " + ex.Message;
        result.EsValido = false;
        result.Datos = null; // Opcional: Puedes definir cómo manejar los datos en caso de error.
      }
      return result;
    }


    public async Task<Result<bool>> update(int id, Producto producto)
    {
      Result<bool> result = new Result<bool>();
      try
      {
        _context.Database.ExecuteSqlInterpolated($@"EXEC ActualizarProductoS
            @id = {id},
            @nombreProducto = {producto.NombreProducto},
            @descripcionProducto = {producto.DescripcionProducto},
            @precio = {producto.Precio},
            @existencia = {producto.Existencia},
            @TipoProducto_Id = {producto.TipoProductoId}");

        result.Id = 1;
        result.Mensaje = "Producto actualizado exitosamente.";
        result.EsValido = true;
        result.Datos = true;
      }
      catch (Exception ex)
      {
        // Manejo de errores en caso de excepción
        result.Id = 0;
        result.Mensaje = "Error al actualizar el producto: " + ex.Message;
        result.EsValido = false;
        result.Datos = false;
      }
      return result;
    }


    public async Task<Result<bool>> delete(int id)
    {
      Result<bool> result = new Result<bool>();
      try
      {
        _context.Database.ExecuteSqlInterpolated($@"EXEC DeleteProducto @ProductoID = {id}");

        result.Id = 1;
        result.Mensaje = "Producto eliminado exitosamente.";
        result.EsValido = true;
        result.Datos = true;
      }
      catch (Exception ex)
      {
        // Manejo de errores en caso de excepción
        result.Id = 0;
        result.Mensaje = "Error al eliminar el producto: " + ex.Message;
        result.EsValido = false;
        result.Datos = false;
      }
      return result;
    }

  }
}

