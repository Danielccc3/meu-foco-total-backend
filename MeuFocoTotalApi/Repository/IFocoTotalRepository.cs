using MeuFocoTotalApi.Model;
using System.Net;

namespace MeuFocoTotalApi.Repository
{
    public interface IFocoTotalRepository
    {
        (HttpStatusCode, string) CadastroAdd(FocoTotalCadastroModel cadastro);
        (HttpStatusCode, IEnumerable<FocoTotalTodosViewModel>) CadastroGetTodos();
        (HttpStatusCode, IEnumerable<FocoTotalTodosViewModel>) CadastroGetTodosEmAndamento();
        (HttpStatusCode, string) UpdateTempo(int id, int tempo);
        (HttpStatusCode, string) FinalizaTempo(int id, int tempo);
        (HttpStatusCode, string) DeletarRegistro(int id);
    }
}
