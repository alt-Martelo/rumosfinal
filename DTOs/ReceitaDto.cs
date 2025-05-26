using System.ComponentModel.DataAnnotations;

namespace Project1_Angular.DTOs
{
    public class ReceitaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public List<string> Ingredientes { get; set; }
        public string CriadoPorUsername { get; set; }
        public DateTime DataCriacao { get; set; }
    }

    public class ReceitaCreateDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string Categoria { get; set; }
        public List<string> Ingredientes { get; set; }
    }

    public class ReceitaUpdateDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public List<string> Ingredientes { get; set; }
    }

   
}
