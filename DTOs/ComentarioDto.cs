using System.ComponentModel.DataAnnotations;

namespace Project1_Angular.DTOs
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string AutorUsername { get; set; }
        public DateTime DataCriacao { get; set; }
    }

    public class ComentarioCreateDto
    {
        [Required]
        public string Texto { get; set; }

        [Required]
        public int ReceitaId { get; set; }
    }

    public class ComentarioUpdateDto
    {
        [Required]
        public string Texto { get; set; }
    }

}
