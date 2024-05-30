using System.ComponentModel.DataAnnotations;

namespace TarefasPlus.Mvc.Models
{
    public enum StatusTarefaViewModel
    {
        Aberta = 0,

        [Display(Name="Concluída")]
        Concluida = 1,
        
        Cancelada = 2
    }
}