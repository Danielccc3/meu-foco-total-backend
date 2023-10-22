using MeuFocoTotalApi.DbScript;
using MeuFocoTotalApi.Model;
using System.Net;

namespace MeuFocoTotalApi.Repository
{
    public class FocoTotalRepository : IFocoTotalRepository
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
                var retorno = Query(_focoTotalDbScript.CadastroGetTodos());
                return (HttpStatusCode.OK, retorno);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return (HttpStatusCode.BadRequest, null);
            }
        }

        public (HttpStatusCode, IEnumerable<FocoTotalUpdateTempoModel>) UpdateTempo(int id, int tempo)
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
