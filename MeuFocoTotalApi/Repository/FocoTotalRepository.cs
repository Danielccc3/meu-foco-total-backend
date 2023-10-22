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
    }
}
