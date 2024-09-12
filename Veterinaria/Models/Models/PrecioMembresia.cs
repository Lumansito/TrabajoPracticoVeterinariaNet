using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class PrecioMembresia
{
    public int CodMembresia { get; set; }

    public DateOnly FechaVigencia { get; set; }

    public decimal? Precio { get; set; }

    public virtual Membresia CodMembresiaNavigation { get; set; } = null!;
}
