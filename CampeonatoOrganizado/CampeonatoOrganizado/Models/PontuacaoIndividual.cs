using CampeonatoOrganizado.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    [Table("pontuacao_individual")]
    public class PontuacaoIndividual
    {
        [Key]
        public int id_pontuacao { get; set; }
        public int id_competicao { get; set; }
        public int id_atleta { get; set; }
        public int pontos { get; set; } = 0;
        public bool? byes { get; set; } //= false;
        public Atleta? Atleta { get; set; }
    }
}