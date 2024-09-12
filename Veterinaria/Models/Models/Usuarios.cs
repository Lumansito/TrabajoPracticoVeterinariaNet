using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Usuarios
{
    public int Dni { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Mail { get; set; }

    public string? Telefono { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Contraseña { get; set; }

    public string? Rol { get; set; }

    public bool? IsAdmin { get; set; }

    public virtual ICollection<Atencion> Atencion { get; set; } = new List<Atencion>();

    public virtual ICollection<Especialidades> CodEspecialidad { get; set; } = new List<Especialidades>();

    public virtual ICollection<Jornada> Jornada { get; set; } = new List<Jornada>();
}
