using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Atencion
{
    public int IdAtencion { get; set; }

    public DateTime? FechaHoraAtencion { get; set; }

    public int? DniCliente { get; set; }

    public int? NroMascota { get; set; }

    public int? DniProfesional { get; set; }

    public string? Observaciones { get; set; }

    public decimal? MontoApagar { get; set; }

    public string? MotivoAtencion { get; set; }

    public DateTime? FechaHoraPago { get; set; }

    public virtual AtencionesServicios? AtencionesServicios { get; set; }

    public virtual Usuarios? DniProfesionalNavigation { get; set; }

    public virtual Mascotas? Mascotas { get; set; }
}
