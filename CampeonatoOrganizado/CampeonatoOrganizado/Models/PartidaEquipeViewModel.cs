using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    public class PartidaEquipeViewModel
    {
        public int IdPartidaEquipe { get; set; }
        public int IdCompeticao { get; set; }
        public int IdEquipe1 { get; set; }
        public int? IdEquipe2 { get; set; }
        public string? Resultado { get; set; }
        public string Fase { get; set; } // Fase da partida (Classificatórias, Oitavas, etc.)
    }
}