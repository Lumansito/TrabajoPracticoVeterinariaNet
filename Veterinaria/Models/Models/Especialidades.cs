using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Especialidades
{
    public int CodEspecialidad { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Servicios> CodServicio { get; set; } = new List<Servicios>();

    public virtual ICollection<Usuarios> DniProfesional { get; set; } = new List<Usuarios>();
}
