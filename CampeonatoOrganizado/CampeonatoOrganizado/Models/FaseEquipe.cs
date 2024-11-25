using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    [Table("fase_equipe")]
    public class FaseEquipe
    {
        [Key]
        [Column("id_fase_equipe")]
        public int IdFaseEquipe { get; set; }

        [Required]
        [Column("id_equipe")]
        public int IdEquipe { get; set; }

        [Required]
        [Column("fase_partida")]
        public Fase FasePartida { get; set; } // Usando enum para evitar strings arbitrárias

        [Required]
        [Column("id_competicao")]
        public int IdCompeticao { get; set; }

        // Relacionamentos (Opcional)
        [ForeignKey("IdEquipe")]
        public Equipe Equipe { get; set; } // Classe `Equipe` deve existir

        [ForeignKey("IdCompeticao")]
        public Competicao Competicao { get; set; } // Classe `Competicao` deve existir
    }

    public enum Fase
    {
        Classificatorias,
        Oitavas,
        Quartas,
        Semi,
        Final
    }
}
