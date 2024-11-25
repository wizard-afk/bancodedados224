using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Cliente
{
    public int PessoaId { get; set; }

    public bool? Preferencial { get; set; }

    public virtual Pessoa Pessoa { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
