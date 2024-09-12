using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Especies
{
    public int CodEspecie { get; set; }

    public string? NombreEspecie { get; set; }

    public virtual ICollection<Mascotas> Mascotas { get; set; } = new List<Mascotas>();
}
