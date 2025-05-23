namespace Project1_Angular.Models
{
    public class Utilizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Receita> Receitas { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }

    }
}
