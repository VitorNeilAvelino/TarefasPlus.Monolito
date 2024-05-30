namespace TarefasPlus.WebApi.Models
{
    public class TarefaQueryModel
    {
        public const int TodosStatus = -1;
        public string? Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int StatusTarefa { get; set; } = TodosStatus;
        public int RegistrosIgnorados { get; set; } = 0;
        public int RegistrosPorPagina { get; set; } = 10;
    }
}