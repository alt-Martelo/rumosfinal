namespace Project1_Angular.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public int Dificuldade { get; set; } // 1 a 5
        public int DuracaoMinutos { get; set; }

        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        public ICollection<IngredienteReceita> Ingredientes { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
    }
}
