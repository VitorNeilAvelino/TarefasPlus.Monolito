using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TarefasPlus.Repositorios.Http.Mensagens;

namespace TarefasPlus.Mvc.Models
{
    public class TarefaViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Data { get; set; } = DateTime.Today;
        
        [Required]
        public StatusTarefaViewModel Status { get; set; }

        public string DescricaoStatus => Status.ToString();

        public static TarefaMensagem Mapear(TarefaViewModel model)
        {
            var mensagem = new TarefaMensagem();

            mensagem.Id = model.Id;
            mensagem.Descricao = model.Descricao;
            mensagem.Status = Enum.Parse<StatusTarefaMensagem>(model.Status.ToString());
            mensagem.Data = model.Data;

            return mensagem;
        }

        internal static List<TarefaViewModel> Mapear(List<TarefaMensagem> resposta)
        {
            var tarefas = new List<TarefaViewModel>();

            foreach (var tarefa in resposta)
            {
                tarefas.Add(Mapear(tarefa));
            }

            return tarefas;
        }

        internal static TarefaViewModel Mapear(TarefaMensagem mensagem)
        {
            var tarefa = new TarefaViewModel();

            tarefa.Data = mensagem.Data;
            tarefa.Status = Enum.Parse<StatusTarefaViewModel>(mensagem.Status.ToString());
            tarefa.Descricao = mensagem.Descricao;
            tarefa.Id = mensagem.Id;

            return tarefa;
        }
    }
}