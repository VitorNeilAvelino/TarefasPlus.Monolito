namespace TarefasPlus.Mvc.Models
{
    public class TarefaPaginacaoViewModel
    {
        public int RegistrosIgnorados { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public List<TarefaViewModel>? Tarefas { get; set; }

        //internal static TarefaPaginacaoViewModel Mapear(TarefaPaginacaoMensagem mensagem)
        //{
        //    var model = new TarefaPaginacaoViewModel();

        //    model.NumeroPagina = mensagem.NumeroPagina;
        //    model.RegistrosPorPagina = mensagem.RegistrosPorPagina;
        //    model.TotalRegistros = mensagem.TotalRegistros;
        //    model.TotalPaginas = mensagem.TotalPaginas;

        //    if (mensagem.Tarefas != null && mensagem.Tarefas.Count > 0)
        //    {
        //        model.Tarefas = new List<TarefaViewModel>();

        //        foreach (var tarefa in mensagem.Tarefas)
        //        {
        //            model.Tarefas.Add(TarefaViewModel.Mapear(tarefa));
        //        }
        //    }

        //    return model;
        //}
    }
}