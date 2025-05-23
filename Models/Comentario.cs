namespace Project1_Angular.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int Rating { get; set; }

        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }

        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
