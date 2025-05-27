using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Project1_Angular.Models
{
    [PrimaryKey("ReceitaId","IngredienteId")]
    public class IngredienteReceita
    {

        //public int ReceitaId { get; set; } // PK
        public Receita Receita { get; set; }
        
        //public int IngredienteId { get; set; } // PK
        public Ingrediente Ingrediente { get; set; }

        public double Quantidade { get; set; }
        
    }
}
