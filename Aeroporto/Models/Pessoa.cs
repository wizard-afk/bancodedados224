using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Pessoa
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefone { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Piloto? Piloto { get; set; }
}
