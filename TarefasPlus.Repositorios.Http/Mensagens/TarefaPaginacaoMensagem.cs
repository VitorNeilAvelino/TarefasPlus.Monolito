namespace TarefasPlus.Repositorios.Http.Mensagens
{
    public class TarefaPaginacaoMensagem
    {
        public int RegistrosIgnorados { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public List<TarefaMensagem>? Tarefas { get; set; }
    }
}