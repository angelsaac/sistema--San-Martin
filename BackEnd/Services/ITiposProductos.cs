using SistemaABC.Models;

namespace SistemaABC.Services
{
  public interface ITiposProductos
  {
    Task<Result<List<TiposProducto>>> getList();
    Task<Result<TiposProducto>> getByID(int id);

    Task<Result<TiposProducto>>add(TiposProducto tipoProducto);
    Task<Result<bool>> delete(int id);

  }
}


