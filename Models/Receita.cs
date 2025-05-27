
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_Angular.Models
{
    public class Receita
    {
        public  DateTime DataCriacao { get; }= DateTime.UtcNow ; // listagem db hora check

        public int ReceitaId { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public required string Categoria { get; set; }
        public int Dificuldade { get; set; } // 1 a 5
        public int DuracaoMinutos { get; set; }

        [NotMapped] //não vai para db
        public double AverageRating { get { if (Comentarios.IsNullOrEmpty()) return 0;
                return Comentarios.Average(c => c.Rating);} }
        // public int UtilizadorId { get; set; }
        public  ApplicationUser Utilizador { get; set; } // required 
        public  ICollection<IngredienteReceita> Ingredientes { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
    }
}
