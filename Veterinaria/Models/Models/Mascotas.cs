using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Mascotas
{
    public int DniCliente { get; set; }

    public int NroMascota { get; set; }

    public string? NombreMascota { get; set; }

    public int? CodRaza { get; set; }

    public int? CodEspecie { get; set; }

    public DateOnly? FechaNac { get; set; }

    public DateOnly? FechaDefuncion { get; set; }

    public virtual ICollection<Atencion> Atencion { get; set; } = new List<Atencion>();

    public virtual Especies? CodEspecieNavigation { get; set; }

    public virtual Raza? CodRazaNavigation { get; set; }

    public virtual Clientes DniClienteNavigation { get; set; } = null!;
}
