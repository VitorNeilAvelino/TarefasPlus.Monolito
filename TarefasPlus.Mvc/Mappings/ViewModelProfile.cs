using AutoMapper;
using TarefasPlus.Mvc.Models;
using TarefasPlus.Repositorios.Http.Mensagens;

namespace TarefasPlus.Mvc.Mappings
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<TarefaQueryMensagem, TarefaQueryViewModel>().ReverseMap();
            CreateMap<TarefaPaginacaoMensagem, TarefaPaginacaoViewModel>().ReverseMap();
            CreateMap<TarefaMensagem, TarefaViewModel>().ReverseMap();
        }
    }
}