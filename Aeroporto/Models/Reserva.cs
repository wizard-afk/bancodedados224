﻿using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int? ClienteId { get; set; }

    public int? VooId { get; set; }

    public int? PoltronaId { get; set; }

    public DateTime? DataReserva { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Poltrona? Poltrona { get; set; }

    public virtual Voo? Voo { get; set; }
}
