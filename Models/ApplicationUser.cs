using Microsoft.AspNetCore.Identity;

namespace Project1_Angular.Models
{
    public class ApplicationUser : IdentityUser
    {
        public  ICollection<Receita> Receitas { get; set; }
        public  ICollection<Comentario> Comentarios { get; set; }

        public bool isAdmin { get; set; }
    }
}