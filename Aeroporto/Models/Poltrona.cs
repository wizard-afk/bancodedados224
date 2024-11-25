﻿using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Poltrona
{
    public int Id { get; set; }

    public int? AeronaveId { get; set; }

    public string Numero { get; set; } = null!;

    public string Localizacao { get; set; } = null!;

    public bool? Disponivel { get; set; }

    public virtual Aeronafe? Aeronave { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
