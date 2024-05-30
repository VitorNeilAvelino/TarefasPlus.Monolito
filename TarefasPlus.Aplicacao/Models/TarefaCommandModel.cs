using System.ComponentModel.DataAnnotations;
using TarefasPlus.Dominio;
using TarefasPlus.Dominio.Entidades;

namespace TarefasPlus.WebApi.Models
{
    public class TarefaCommandModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        public DateTime Data { get; set; }
        
        [Required]
        public StatusTarefa Status { get; set; }
        
        public static Tarefa Mapear(TarefaCommandModel model)
        {
            var tarefa = new Tarefa();
            tarefa.Id = model.Id;
            tarefa.Data = model.Data;
            tarefa.Status = model.Status;
            tarefa.Descricao = model.Descricao;

            return tarefa;
        }
    }
}