using System;
using System.Collections.Generic;

namespace SistemaABC.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string? DescripcionProducto { get; set; } = null!;

    public decimal? Precio { get; set; } = null!;

    public decimal? Existencia { get; set; } = null!;

    public int? TipoProductoId { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaEliminado { get; set; }

    public int? Status { get; set; }

    //public virtual TiposProducto? TipoProducto { get; set; }
}
