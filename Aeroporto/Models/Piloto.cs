using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Piloto
{
    public int PessoaId { get; set; }

    public string NumeroLicenca { get; set; } = null!;

    public virtual Pessoa Pessoa { get; set; } = null!;

    public virtual ICollection<Voo> Voos { get; set; } = new List<Voo>();
}
