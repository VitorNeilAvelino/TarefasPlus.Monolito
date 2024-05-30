using Microsoft.EntityFrameworkCore;
using TarefasPlus.Aplicacao.Models;
using TarefasPlus.Dominio.Entidades;
using TarefasPlus.Repositorios.SqlServer;
using TarefasPlus.WebApi.Models;

namespace TarefasPlus.Aplicacao
{
    public class TarefaAplicacao : ITarefaAplicacao
    {
        private readonly TaferasPlusDbContext _contexto;

        public TarefaAplicacao(TaferasPlusDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task InserirAsync(Tarefa tarefa)
        {
            await _contexto.AddAsync(tarefa);
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Tarefa tarefa)
        {
            _contexto.Entry(tarefa).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int tarefaId)
        {
            var tarefa = await ObterTarefa(tarefaId);

            _contexto.Remove(tarefa);
            await _contexto.SaveChangesAsync();
        }

        private async Task<Tarefa?> ObterTarefa(int tarefaId)
        {
            var tarefa = await _contexto.Tarefas.SingleOrDefaultAsync(t => t.Id == tarefaId);

            if (tarefa == null)
            {
                throw new KeyNotFoundException($"Tarefa com o id {tarefaId} não encontrada.");
            }

            return tarefa;
        }

        public async Task<Tarefa?> SelecionarAsync(int tarefaId)
        {
            return await _contexto.Tarefas.SingleOrDefaultAsync(t => t.Id == tarefaId);
        }

        public async Task<TarefaPaginacao> SelecionarAsync(TarefaQueryModel model)
        {
            var query = _contexto.Tarefas.AsNoTracking();

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                query = query.Where(t => t.Descricao.Contains(model.Descricao));
            }

            if (model.StatusTarefa != TarefaQueryModel.TodosStatus)
            {
                query = query.Where(t => (int)t.Status == model.StatusTarefa);
            }

            if (model.DataInicio.HasValue)
            {
                query = query.Where(t => t.Data >= model.DataInicio);
            }

            if (model.DataFim.HasValue)
            {
                query = query.Where(t => t.Data <= model.DataFim);
            }

            var totalRegistros = await query.CountAsync();

            var tarefasPaginadas = await query
                .Skip(model.RegistrosIgnorados)
                .Take(model.RegistrosPorPagina)
                .OrderByDescending(t => t.Data)
                .ThenBy(t => t.Descricao)
                .ToListAsync();

            return new TarefaPaginacao
            {
                RegistrosIgnorados = model.RegistrosIgnorados,
                RegistrosPorPagina = model.RegistrosPorPagina,
                Tarefas = tarefasPaginadas,
                TotalRegistros = totalRegistros,
                TotalPaginas = (totalRegistros / model.RegistrosPorPagina) + (totalRegistros % model.RegistrosPorPagina == 0 ? 0 : 1)
            };
        }
    }
}