
namespace Project1_Angular.Models
{
    public class Receita
    {
        public  DateTime DataCriacao;

        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public required string Categoria { get; set; }
        public int Dificuldade { get; set; } // 1 a 5
        public int DuracaoMinutos { get; set; }

        public int UtilizadorId { get; set; }
        public required Utilizador Utilizador { get; set; }

        public required ICollection<IngredienteReceita> Ingredientes { get; set; }
        public required ICollection<Comentario> Comentarios { get; set; }
    }
}
