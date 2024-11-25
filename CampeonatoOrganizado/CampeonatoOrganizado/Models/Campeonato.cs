using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampeonatoOrganizado.Models
{
    [Table("campeonato")]
    public class Campeonato
    {
        [Key]
        [Column("id_campeonato")]
        public int IdCampeonato { get; set; }

        [Required]
        [Column("nome_campeonato")]
        [StringLength(255)]
        public string NomeCampeonato { get; set; }

        [Column("data_inicio")]
        public DateTime? DataInicio { get; set; }

        [Column("data_fim")]
        public DateTime? DataFim { get; set; }

        [Required]
        [Column("status_campeonato")]
        [StringLength(20)]
        public string StatusCampeonato { get; set; } = "nao_iniciado";

        [Column("descricao")]
        public string? Descricao { get; set; }

        // Relacionamento: Um campeonato pode ter várias modalidades
        public ICollection<Modalidade> Modalidades { get; set; }
    }
}
