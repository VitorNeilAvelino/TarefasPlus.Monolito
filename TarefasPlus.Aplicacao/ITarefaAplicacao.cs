using TarefasPlus.Aplicacao.Models;
using TarefasPlus.Dominio.Entidades;
using TarefasPlus.WebApi.Models;

namespace TarefasPlus.Aplicacao
{
    public interface ITarefaAplicacao
    {
        Task AtualizarAsync(Tarefa tarefa);
        Task ExcluirAsync(int tarefaId);
        Task InserirAsync(Tarefa tarefa);
        Task<Tarefa?> SelecionarAsync(int tarefaId);
        Task<TarefaPaginacao> SelecionarAsync(TarefaQueryModel model);
    }
}