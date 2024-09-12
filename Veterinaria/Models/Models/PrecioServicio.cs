using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class PrecioServicio
{
    public int CodServicio { get; set; }

    public DateOnly FechaDesde { get; set; }

    public decimal? Precio { get; set; }

    public virtual Servicios CodServicioNavigation { get; set; } = null!;
}
