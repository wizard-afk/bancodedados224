using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    [Keyless] // Necessário porque views geralmente não têm uma chave primária
    [Table("partida_individual_view")] // Opcional, para fins de clareza
    public class PartidaIndividualView
    {
        public int id_partida_individual { get; set; }

        [Column("id_atleta1")]
        public int id_atleta1 { get; set; }

        [Column("id_atleta2")]
        public int? id_atleta2 { get; set; } 

        public string nome_atleta1 { get; set; }
        public string? nome_atleta2 { get; set; }
        public int pontuacao_atleta1 { get; set; }
        public int pontuacao_atleta2 { get; set; }
        public string? resultado_partida { get; set; }


  

    }
}
