using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Servicios
{
    public int CodServicio { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<AtencionesServicios> AtencionesServicios { get; set; } = new List<AtencionesServicios>();

    public virtual ICollection<PrecioServicio> PrecioServicio { get; set; } = new List<PrecioServicio>();

    public virtual ICollection<Especialidades> CodEspecialidad { get; set; } = new List<Especialidades>();
}
