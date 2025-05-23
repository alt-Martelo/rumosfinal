namespace Project1_Angular.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<IngredienteReceita> IngredienteReceitas { get; set; }
    }
}
