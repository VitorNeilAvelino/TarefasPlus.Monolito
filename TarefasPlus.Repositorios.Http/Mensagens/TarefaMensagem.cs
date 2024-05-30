namespace TarefasPlus.Repositorios.Http.Mensagens
{
    public class TarefaMensagem
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public StatusTarefaMensagem Status { get; set; }
    }
}