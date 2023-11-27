using MeuFocoTotalApi.Model;
using System.Net;

namespace MeuFocoTotalApi.Repository
{
    public interface IFocoTotalRepository
    {
        (HttpStatusCode, string) CadastroAdd(FocoTotalCadastroModel cadastro);
        (HttpStatusCode, IEnumerable<FocoTotalTodosViewModel>) CadastroGetTodos();
        (HttpStatusCode, string) UpdateTempo(int id, int tempo);
    }
}
