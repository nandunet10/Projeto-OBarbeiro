using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OBarbeiro.Comum.Modelos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace OBarbeiro.Comum.Servico;

public class ApiToken : IApiToken
{
    private readonly IOptions<DadosBase> _dadosBase;
    private readonly IOptions<LoginResposta> _loginRespostaModel;
    private readonly HttpClient _httpClient;


    public ApiToken(IOptions<DadosBase> dadosBase, IOptions<LoginResposta> loginRespostaModel, IHttpClientFactory httpClient)
    {
        _dadosBase = dadosBase;
        _loginRespostaModel = loginRespostaModel;
        _httpClient = httpClient.CreateClient();
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private async Task ObterToken()
    {
        LoginRequisicao loginRequisicaoModel = new()
        {
            Usuario = _dadosBase.Value.USUARIO,
            Senha = _dadosBase.Value.SENHA

        };

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Login", loginRequisicaoModel);

        if (response.IsSuccessStatusCode)
        {
            LoginResposta loginRespostaModel = JsonConvert.DeserializeObject<LoginResposta>(await response.Content.ReadAsStringAsync());

            if (loginRespostaModel.Autenticado)
            {
                _loginRespostaModel.Value.Autenticado = loginRespostaModel.Autenticado;
                _loginRespostaModel.Value.Usuario = loginRespostaModel.Usuario;
                _loginRespostaModel.Value.DataExpiracao = loginRespostaModel.DataExpiracao;
                _loginRespostaModel.Value.Token = loginRespostaModel.Token;
            }
        }
        else
        {
            throw new Exception("Falha na autenticação, por favor tente novamente !");
        }
    }

    public async Task<string> Obter()
    {
        if (_loginRespostaModel.Value.Autenticado == false)
        {
            await ObterToken();
        }
        else
        {
            if (DateTime.Now >= _loginRespostaModel.Value.DataExpiracao)
            {
                await ObterToken();
            }
        }
        return _loginRespostaModel.Value.Token;
    }
}
