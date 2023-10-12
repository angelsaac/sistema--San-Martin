namespace SistemaABC
{
  public class Result<T>
  {
    public int Id { get; set; }
    public string Mensaje { get; set; }
    public T Datos { get; set; }
    public bool EsValido { get; set; }

    public Result()
    {
      Id = 0;
      Mensaje = string.Empty;
      Datos = default(T);
      EsValido = false;
    }

    public Result(int id, string mensaje, T datos, bool esValido)
    {
      Id = id;
      Mensaje = mensaje;
      Datos = datos;
      EsValido = esValido;
    }
  }

}
