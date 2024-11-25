using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    [Table("atleta")]
    public class Atleta
    {
        [Key]
        public int id_atleta { get; set; }
        public int id_campeonato { get; set; }
        public string? nome_atleta { get; set; }
        public DateTime data_nascimento { get; set; }
        public int id_modalidade { get; set; }

        public ICollection<PontuacaoIndividual>? Pontuacoes { get; set; }
        public ICollection<PartidaIndividual>? Partidas { get; set; }
    }
}
