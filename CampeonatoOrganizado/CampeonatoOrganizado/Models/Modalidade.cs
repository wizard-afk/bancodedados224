using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    [Table("modalidade")]
    public class Modalidade
    {
        [Key]
        [Column("id_modalidade")]
        public int IdModalidade { get; set; }

        [Required]
        [Column("id_campeonato")]
        public int IdCampeonato { get; set; }

        [Required]
        [Column("nome_modalidade")]
        [StringLength(100)]
        public string NomeModalidade { get; set; }

        [Required]
        [Column("tipo_modalidade")]
        [StringLength(20)]
        public string TipoModalidade { get; set; }

        [Column("qtd_minima_atletas")]
        public int? QtdMinimaAtletas { get; set; }

        [Column("qtd_maxima_atletas")]
        public int? QtdMaximaAtletas { get; set; }

        // Relacionamento: Cada modalidade pertence a um campeonato
        [ForeignKey("IdCampeonato")]
        public Campeonato Campeonato { get; set; }
    }
}
