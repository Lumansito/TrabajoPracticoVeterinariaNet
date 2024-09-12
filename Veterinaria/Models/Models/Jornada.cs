using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Jornada
{
    public string NombreDia { get; set; } = null!;

    public TimeOnly HoraInicioJornada { get; set; }

    public TimeOnly? HoraFinJornada { get; set; }

    public virtual ICollection<Usuarios> DniProfesional { get; set; } = new List<Usuarios>();
}
