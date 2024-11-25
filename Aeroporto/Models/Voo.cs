using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Voo
{
    public int Id { get; set; }

    public int? AeronaveId { get; set; }

    public int? AeroportoOrigem { get; set; }

    public int? AeroportoDestino { get; set; }

    public DateTime HorarioSaida { get; set; }

    public DateTime HorarioPrevistoChegada { get; set; }

    public int? PilotoId { get; set; }

    public virtual Aeronafe? Aeronave { get; set; }

    public virtual Aeroporto? AeroportoDestinoNavigation { get; set; }

    public virtual Aeroporto? AeroportoOrigemNavigation { get; set; }

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Piloto? Piloto { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
