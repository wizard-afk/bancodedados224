using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Aeroporto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Localizacao { get; set; } = null!;

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();

    public virtual ICollection<Voo> VooAeroportoDestinoNavigations { get; set; } = new List<Voo>();

    public virtual ICollection<Voo> VooAeroportoOrigemNavigations { get; set; } = new List<Voo>();
}
