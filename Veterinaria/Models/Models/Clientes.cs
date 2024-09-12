using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Clientes
{
    public int DniCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Mail { get; set; }

    public string? Telefono { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public virtual ICollection<ClienteMembresia> ClienteMembresia { get; set; } = new List<ClienteMembresia>();

    public virtual ICollection<Mascotas> Mascotas { get; set; } = new List<Mascotas>();
}
