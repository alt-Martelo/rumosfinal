namespace Project1_Angular.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; } // pk
        public required string Texto { get; set; }
        public required int Rating { get; set; }

        // public int ReceitaId { get; set; }
        public  Receita Receita { get; set; }

        //public int UtilizadorId { get; set; }
        public  ApplicationUser Utilizador { get; set; }
    }
}
