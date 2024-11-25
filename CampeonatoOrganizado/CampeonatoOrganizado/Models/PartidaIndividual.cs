using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    [Table("partida_individual")]
    public class PartidaIndividual
    {
        [Key]
        [Column("id_partida_individual")]
        public int id_partida_individual { get; set; }

        [Column("id_competicao")]
        public int id_competicao { get; set; }

        [Column("id_atleta1")]
        public int id_atleta1 { get; set; }

        [Column("id_atleta2")]
        public int? id_atleta2 { get; set; }

        [Column("resultado_partida")]
        public string? resultado_partida { get; set; }

        [ForeignKey("id_atleta1")]
        public Atleta atleta1 { get; set; }

        [ForeignKey("id_atleta2")]
        public Atleta atleta2 { get; set; }
    }
}
