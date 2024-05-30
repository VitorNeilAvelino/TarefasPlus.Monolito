using TarefasPlus.Repositorios.Http.Mensagens;

namespace TarefasPlus.Repositorios.Http.Interfaces
{
    public interface ITarefaRepositorio : ICrudRepositorio<TarefaMensagem>
    {
        Task<TarefaPaginacaoMensagem> Get(TarefaQueryMensagem query);
    }
}