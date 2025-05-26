namespace Project1_Angular.Models
{
    public class IngredienteReceita
    {
        internal string Nome;

        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }

        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }

        public double Quantidade { get; set; }
        public string Unidade { get; set; }
    }
}
