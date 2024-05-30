using System.Net.Http.Json;
using TarefasPlus.Repositorios.Http.Interfaces;

namespace TarefasPlus.Repositorios.Http
{
    public class CrudRepositorio<T> : ICrudRepositorio<T>
    {
        protected readonly HttpClient _httpClient;

        public string Caminho { get; set; }
        public string? AuthorizationToken { get; set; }

        public CrudRepositorio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> Get(int id)
        {
            using var resposta = await _httpClient.GetAsync($"{Caminho}/{id}");
            return await resposta.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> Post(T entidade)
        {
            using var resposta = await _httpClient.PostAsJsonAsync(Caminho, entidade);
            return await resposta.Content.ReadFromJsonAsync<T>();
        }

        public async Task Put(T entidade, int id)
        {
            using var resposta = await _httpClient.PutAsJsonAsync($"{Caminho}/{id}", entidade);
            resposta.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            using var resposta = await _httpClient.DeleteAsync($"{Caminho}/{id}");
            resposta.EnsureSuccessStatusCode();
        }
    }
}