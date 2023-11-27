using MeuFocoTotalApi.DbScript;
using MeuFocoTotalApi.Model;
using MeuFocoTotalApi.Common;
using System.Net;

namespace MeuFocoTotalApi.Repository
{
    public class FocoTotalRepository : AcessoDados, IFocoTotalRepository
    {
        private FocoTotalDbScript _focoTotalDbScript = new FocoTotalDbScript();


        public (HttpStatusCode, string) CadastroAdd(FocoTotalCadastroModel cadastro)
        {

            try
            {
                Execute(_focoTotalDbScript.CadastroAdd(cadastro));
                return (HttpStatusCode.OK, "");
            }
            catch (Exception ex)
            {
                return (HttpStatusCode.BadRequest, "");
            }
        }

        public (HttpStatusCode, IEnumerable<FocoTotalTodosViewModel>) CadastroGetTodos()
        {
            try
            {
                var retorno = Query<FocoTotalTodosViewModel>(_focoTotalDbScript.CadastroGetTodos());
                return (HttpStatusCode.OK, retorno);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return (HttpStatusCode.BadRequest, null);
            }
        }

        public (HttpStatusCode, string) UpdateTempo(int id, int tempo)
        {
            try
            {
                var retorno = Execute(_focoTotalDbScript.UpdateTempo(id, tempo));
                return (HttpStatusCode.OK, retorno);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return (HttpStatusCode.BadRequest, null);
            }
        }
    }
}
