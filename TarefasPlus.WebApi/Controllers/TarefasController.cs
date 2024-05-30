using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasPlus.Aplicacao;
using TarefasPlus.Aplicacao.Models;
using TarefasPlus.Dominio.Entidades;
using TarefasPlus.WebApi.Models;

namespace TarefasPlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaAplicacao _tarefaAplicacao;

        public TarefasController(ITarefaAplicacao tarefaAplicacao)
        {
            _tarefaAplicacao = tarefaAplicacao;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Tarefa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Tarefa>> Get(int id)
        {
            var tarefa = await _tarefaAplicacao.SelecionarAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        [HttpGet]
        [ProducesResponseType(typeof(TarefaPaginacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TarefaPaginacao>> Get([FromQuery]TarefaQueryModel model)
        {
            if (model.DataInicio.HasValue && model.DataFim.HasValue)
            {
                if (model.DataInicio > model.DataFim)
                {
                    ModelState.AddModelError("DataInicio", $"A data inicial {model.DataInicio} deve ser menor que a data final {model.DataFim}.");
                    return BadRequest(ModelState);
                }
            }

            return await _tarefaAplicacao.SelecionarAsync(model);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Tarefa), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tarefa>> Post(TarefaCommandModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tarefa = TarefaCommandModel.Mapear(model);

            await _tarefaAplicacao.InserirAsync(tarefa);

            return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, TarefaCommandModel model)
        {
            if (id != model.Id)
            {
                ModelState.AddModelError("Id", $"O id da tarefa passado na URL ({id}) não equivale ao id da Tarefa que está sendo editada - {model.Id}.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tarefa = TarefaCommandModel.Mapear(model);

            try
            {
                await _tarefaAplicacao.AtualizarAsync(tarefa);
            }
            catch (DbUpdateConcurrencyException)
            {
                var tarefaExistente = await _tarefaAplicacao.SelecionarAsync(id);

                if (tarefaExistente == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tarefaAplicacao.ExcluirAsync(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}