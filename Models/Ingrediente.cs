namespace Project1_Angular.Models
{
    public class Ingrediente
    {
        public int IngredienteId { get; set; }
        public required string Nome { get; set; }

        public required string Unidade { get; set; }
        // public ICollection<IngredienteReceita> IngredienteReceitas { get; set; }
    }
}
