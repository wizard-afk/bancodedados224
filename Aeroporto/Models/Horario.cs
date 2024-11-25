using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Horario
{
    public int Id { get; set; }

    public int? VooId { get; set; }

    public DateTime HorarioSaida { get; set; }

    public DateTime HorarioChegada { get; set; }

    public virtual Voo? Voo { get; set; }
}
