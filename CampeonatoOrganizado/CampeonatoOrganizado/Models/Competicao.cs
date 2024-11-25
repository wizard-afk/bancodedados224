using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    [Table("competicao")]
    public class Competicao
    {
        [Key]
        [Column("id_competicao")]
        public int IdCompeticao { get; set; }

        [Required]
        [Column("id_modalidade")]
        public int IdModalidade { get; set; }

        [Required]
        [Column("status_competicao")]
        [StringLength(20)]
        public string StatusCompeticao { get; set; } = "pendente";

        // Relacionamento com Modalidade (opcional)
        [ForeignKey("IdModalidade")]
        public Modalidade Modalidade { get; set; } // Classe `Modalidade` deve existir
    }
}
