using TarefasPlus.Dominio.Entidades;

namespace TarefasPlus.Aplicacao.Models
{
    public class TarefaPaginacao
    {
        public int RegistrosIgnorados { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public List<Tarefa>? Tarefas { get; set; }
    }
}