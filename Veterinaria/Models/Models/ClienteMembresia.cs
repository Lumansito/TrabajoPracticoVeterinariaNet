using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class ClienteMembresia
{
    public int CodMembresia { get; set; }

    public int DniCliente { get; set; }

    public DateOnly? FechaDesde { get; set; }

    public virtual Membresia CodMembresiaNavigation { get; set; } = null!;

    public virtual Clientes DniClienteNavigation { get; set; } = null!;
}
