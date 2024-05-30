namespace TarefasPlus.Repositorios.Http.Interfaces
{
    public interface ICrudRepositorio<T>
    {
        string Caminho { get; set; }
        string? AuthorizationToken { get; set; }
        Task Delete(int id);
        Task<T> Get(int id);
        Task<T> Post(T entidade);
        Task Put(T entidade, int id);
    }
}