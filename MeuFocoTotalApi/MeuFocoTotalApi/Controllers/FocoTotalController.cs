using MeuFocoTotalApi.Model;
using MeuFocoTotalApi.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MeuFocoTotalApi.Controllers
{
    [EnableCors("CorsAllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class FocoTotalController : MainController
    {
        private readonly IFocoTotalRepository _FocoTotalRepository;
        public FocoTotalController(IFocoTotalRepository focoTotalRepository)
        {
            _FocoTotalRepository = focoTotalRepository;
        }

        /// <summary>
        /// AddCadastro
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpPost("Cadastrar")]
        public IActionResult DescargaAdd(FocoTotalCadastroModel Cadastro)
        {

            return CustomResponse(_FocoTotalRepository.CadastroAdd(Descarga));

        }
    }
}
