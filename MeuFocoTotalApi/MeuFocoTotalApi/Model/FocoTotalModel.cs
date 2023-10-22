namespace MeuFocoTotalApi.Model
{
    public class FocoTotalTodosViewModel
    {
        public int ID { get; set; }
        public int TEMPO { get; set; }
        public string? NOME { get; set; }
        public string? CPF { get; set; }
        public int NUMEROCADASTRO { get; set; }
    }
    public class FocoTotalCadastroModel
    {
        public int ID { get; set; }
        public int TEMPO { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }
        public int NUMEROCADASTRO { get; set; }
    }
    public class FocoTotalUpdateTempoModel
    {
        public int ID { get; set; }
        public int TEMPO { get; set; }
    }
}
