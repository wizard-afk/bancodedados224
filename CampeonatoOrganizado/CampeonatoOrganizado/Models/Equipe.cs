using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    [Table("equipe")]
    public class Equipe
    {
        [Key]
        [Column("id_equipe")]
        public int IdEquipe { get; set; }

        [Required]
        [Column("id_campeonato")]
        public int IdCampeonato { get; set; }

        [Required]
        [Column("id_modalidade")]
        public int IdModalidade { get; set; }

        [Required]
        [Column("nome_equipe")]
        [StringLength(100)]
        public string NomeEquipe { get; set; }

        // Relacionamento com Modalidade (opcional)
        [ForeignKey("IdModalidade")]
        public Modalidade Modalidade { get; set; } // Classe `Modalidade` deve existir

        // Relacionamento com Campeonato (opcional)
        [ForeignKey("IdCampeonato")] 
        public Campeonato Campeonato { get; set; } // Classe `Campeonato` deve existir
    }
}
