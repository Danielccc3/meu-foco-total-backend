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
        public IActionResult CadastroAdd(FocoTotalCadastroModel Cadastro)
        {

            return CustomResponse(_FocoTotalRepository.CadastroAdd(Cadastro));

        }

        /// <summary>
        /// GetTodosOsCadastros
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpGet("CadastroGetTodos")]
        public IActionResult CadastroGetTodos()
        {

            return CustomResponse(_FocoTotalRepository.CadastroGetTodos());

        }

        /// <summary>
        /// GetTodosOsCadastros
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpGet("CadastroGetTodosEmAndamento")]
        public IActionResult CadastroGetTodosEmAndamento()
        {

            return CustomResponse(_FocoTotalRepository.CadastroGetTodosEmAndamento());

        }

        /// <summary>
        /// UpdateDoTempo
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpPut("UpdateTempo")]
        public IActionResult UpdateTempo(int id, int tempo)
        {

            return CustomResponse(_FocoTotalRepository.UpdateTempo(id, tempo));

        }

        /// <summary>
        /// UpdateDoTempo
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpPut("FinalizaTempo")]
        public IActionResult FinalizaTempo(int id, int tempo)
        {

            return CustomResponse(_FocoTotalRepository.FinalizaTempo(id, tempo));

        }

        /// <summary>
        /// UpdateDoTempo
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpDelete("DeletarRegistro")]
        public IActionResult DeletarRegistro(int id)
        {

            return CustomResponse(_FocoTotalRepository.DeletarRegistro(id));

        }
    }
}
