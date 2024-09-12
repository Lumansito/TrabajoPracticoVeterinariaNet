using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Membresia
{
    public int CodMembresia { get; set; }

    public string? Descripcion { get; set; }

    public int? AntiguedadMinimaCliente { get; set; }

    public virtual ICollection<ClienteMembresia> ClienteMembresia { get; set; } = new List<ClienteMembresia>();

    public virtual ICollection<PrecioMembresia> PrecioMembresia { get; set; } = new List<PrecioMembresia>();
}
