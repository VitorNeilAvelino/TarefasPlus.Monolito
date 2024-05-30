using System.Net.Http.Json;
using TarefasPlus.Repositorios.Http.Apoio;
using TarefasPlus.Repositorios.Http.Interfaces;
using TarefasPlus.Repositorios.Http.Mensagens;

namespace TarefasPlus.Repositorios.Http
{
    public class TarefaRepositorio : CrudRepositorio<TarefaMensagem>, ITarefaRepositorio
    {
        public TarefaRepositorio(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<TarefaPaginacaoMensagem> Get(TarefaQueryMensagem query)
        {
            if (AuthorizationToken != null)
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AuthorizationToken}");
            }

            using var resposta = await _httpClient.GetAsync(string.Concat(Caminho, "?", query.GetQueryString()));

            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadFromJsonAsync<TarefaPaginacaoMensagem>();
            }

            throw new HttpRequestException(resposta.StatusCode.ToString(), null, resposta.StatusCode);
        }
    }
}
