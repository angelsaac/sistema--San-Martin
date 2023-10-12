using SistemaABC.Models;

namespace SistemaABC.Services
{
  public interface IProducto
  {

    Task<Result<List<Producto>>> getList();
    Task<Result<Producto>> getByID(int id);
    Task<Result<Producto>> add(Producto producto);
    Task<Result<bool>> update(int id, Producto producto);
    Task<Result<bool>> delete(int id);

  }
}

