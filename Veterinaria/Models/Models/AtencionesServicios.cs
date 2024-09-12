using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class AtencionesServicios
{
    public int? CodServicio { get; set; }

    public int IdAtencion { get; set; }

    public virtual Servicios? CodServicioNavigation { get; set; }

    public virtual Atencion IdAtencionNavigation { get; set; } = null!;
}
