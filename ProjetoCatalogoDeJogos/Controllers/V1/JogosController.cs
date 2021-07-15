using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCatalogoDeJogos.Exceptions;
using ProjetoCatalogoDeJogos.InputModel;
using ProjetoCatalogoDeJogos.Service;
using ProjetoCatalogoDeJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCatalogoDeJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogo_Service _jogo_Service;

        public JogosController(IJogo_Service jogo_Service)
        {
            _jogo_Service = jogo_Service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogo_ViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            
            var jogos = await _jogo_Service.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<Jogo_ViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogo_Service.Obter(idJogo);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }


        [HttpPost]

        public async Task<ActionResult<Jogo_ViewModel>> InserirJogo([FromBody] Jogo_InputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogo_Service.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastradoException ex)

            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] Jogo_InputModel jogoInputModel)
        {
            try
            {
                await _jogo_Service.Atualizar(idJogo, jogoInputModel);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogo_Service.Atualizar(idJogo, preco);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogo_Service.Remover(idJogo);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }





    
    }
}
