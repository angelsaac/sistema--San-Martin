using System;
using System.Collections.Generic;

namespace SistemaABC.Models;

public partial class TiposProducto
{
    public int Id { get; set; }

    public string NombreTipoProducto { get; set; } = null!;

    public string DescripcionTipoProducto { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaEliminado { get; set; }

    public int? Status { get; set; }

    //public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
