namespace MeuFocoTotalApi.Model
{
    public class FocoTotalTodosViewModel
    {
        public int ID { get; set; }
        public int USERID { get; set; }
        public int TEMPOOCORRIDO { get; set; }
        public string? NOMEUSUARIO { get; set; }

    }
    public class FocoTotalCadastroModel
    {
        public int ID { get; set; }
        public int USERID { get; set; }
        public int TEMPOOCORRIDO { get; set; }
        public string? NOMEUSUARIO { get; set; }

    }
    public class FocoTotalUpdateTempoModel
    {
        public int ID { get; set; }
        public int USERID { get; set; }
        public int TEMPOOCORRIDO { get; set; }
    }
}
