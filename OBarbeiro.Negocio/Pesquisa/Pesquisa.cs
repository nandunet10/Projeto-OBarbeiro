using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Infra.Contexts;

namespace OBarbeiro.Negocio.Pesquisa
{
    public class Pesquisa : IPesquisa
    {
        private readonly OBarbeiroDbContext _context;

        public Pesquisa(OBarbeiroDbContext context)
        {
            _context = context;
        }

        public async Task<List<PesquisaViewModel>> PesquisarEmpresas(PesquisarEmpresasViewModel pesquisar)
        {
            try
            {
                SqlParameter nomeBarbearia, cidade, uf;
                nomeBarbearia = new SqlParameter("nomeBarbearia", $"{pesquisar.NomeBarbearia}");
                cidade = new SqlParameter("cidade", $"{pesquisar.Cidade}");
                uf = new SqlParameter("uf", $"{pesquisar.UF}");

                var empresas = new List<Modelo.Modelos.Empresa>();

                empresas = await _context.Empresas
                    .FromSqlRaw($"SELECT TOP 100 * FROM dbo.Empresas " +
                                            $"WHERE (@nomeBarbearia = '' or @nomeBarbearia is null or @nomeBarbearia like '%@nomeBarbearia%') " +
                                            $"AND (@cidade = '' or @cidade is null or cidade = @cidade)" +
                                            $"AND (@uf = '' or @uf is null or uf = @uf)", nomeBarbearia, cidade, uf).ToListAsync();


                var pesquisaEmpresas = new List<PesquisaViewModel>();

                foreach (var emp in empresas)
                {
                    var empViewModel = new PesquisaViewModel()
                    {
                        Email = emp.Email,
                        NomeBarbearia = emp.NomeBarbearia,
                        Celular = emp.Celular,
                        Telefone = emp.Telefone,
                        Cep = emp.Cep,
                        Cidade = emp.Cidade,
                        Complemento = emp.Complemento,
                        Logradouro = emp.Logradouro,
                        Numero = emp.Numero,
                        UF = emp.UF
                    };
                    pesquisaEmpresas.Add(empViewModel);
                }

                return pesquisaEmpresas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
