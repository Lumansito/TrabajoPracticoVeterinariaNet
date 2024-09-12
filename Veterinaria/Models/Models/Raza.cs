using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Raza
{
    public int CodRaza { get; set; }

    public string? NombreRaza { get; set; }

    public virtual ICollection<Mascotas> Mascotas { get; set; } = new List<Mascotas>();
}
