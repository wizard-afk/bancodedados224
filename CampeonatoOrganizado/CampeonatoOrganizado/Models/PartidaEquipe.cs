using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    [Table("partida_equipe")]
    public class PartidaEquipe
    {
        [Key]
        [Column("id_partida_equipe")]
        public int IdPartidaEquipe { get; set; }

        [Required]
        [Column("id_competicao")]
        public int IdCompeticao { get; set; }

        [Required]
        [Column("id_equipe1")]
        public int IdEquipe1 { get; set; }

        [Column("id_equipe2")]
        public int? IdEquipe2 { get; set; } // Nullable caso a partida só tenha um time definido inicialmente

        [Column("resultado")]
        public ResultadoPartida? Resultado { get; set; } // Usando enum para evitar strings arbitrárias

        // Relacionamentos (Opcional, dependendo do modelo)
        [ForeignKey("IdCompeticao")]
        public Competicao Competicao { get; set; } // Classe `Competicao` deve existir

        [ForeignKey("IdEquipe1")]
        public Equipe Equipe1 { get; set; } // Classe `Equipe` deve existir

        [ForeignKey("IdEquipe2")]
        public Equipe? Equipe2 { get; set; } // Nullable para id_equipe2
    }

    public enum ResultadoPartida
    {
        Equipe1, // Vencedor foi equipe1
        Equipe2, // Vencedor foi equipe2
        Empate   // Se empates forem possíveis
    }
}
