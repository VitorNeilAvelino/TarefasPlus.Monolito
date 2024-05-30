namespace TarefasPlus.Repositorios.Http.Mensagens
{
    public class TarefaQueryMensagem
    {
        public const int TodosStatus = -1;
        public string? Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int StatusTarefa { get; set; } = TodosStatus;
        public int RegistrosIgnorados { get; set; } = 1;
        public int RegistrosPorPagina { get; set; } = 10;
    }
}