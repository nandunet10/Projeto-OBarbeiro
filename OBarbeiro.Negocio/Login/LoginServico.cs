using OBarbeiro.Comum.Modelos;

namespace OBarbeiro.Negocio;
public class LoginServico
{
    public async Task<LoginResposta> Login(LoginRequisicao loginRequisicaoModel)
    {
        LoginResposta loginRespostaModel = new()
        {
            Autenticado = false,
            Usuario = loginRequisicaoModel.Usuario,
            Token = "",
            DataExpiracao = null
        };

        if (loginRequisicaoModel.Usuario == "UsuarioDevPratica" && loginRequisicaoModel.Senha == "SenhaDevPratica")
        {
            loginRespostaModel = new GeradorToken().GerarToken(loginRespostaModel);
        }

        return loginRespostaModel;
    }
}
