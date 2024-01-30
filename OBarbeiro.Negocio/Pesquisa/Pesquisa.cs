using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Infra.Contexts;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Negocio.Pesquisa
{
    public class Pesquisa : IPesquisa
    {
        private readonly OBarbeiroDbContext _context;

        public Pesquisa(OBarbeiroDbContext context)
        {
            _context = context;
        }

        public async Task<List<RetornoPesquisaEmpresasViewModel>> PesquisarEmpresas(PesquisarEmpresasViewModel pesquisar)
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
                                            $"WHERE (@nomeBarbearia = '' or @nomeBarbearia is null or nomeBarbearia like '%@nomeBarbearia%') " +
                                            $"AND (@cidade = '' or @cidade is null or cidade like '%@cidade%')" +
                                            $"AND (@uf = '' or @uf is null or uf = @uf)", nomeBarbearia, cidade, uf).ToListAsync();


                var pesquisaEmpresas = new List<RetornoPesquisaEmpresasViewModel>();

                foreach (var emp in empresas)
                {
                    var empViewModel = new RetornoPesquisaEmpresasViewModel()
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

        public async Task<List<RetornoPesquisaAgendamentoViewModel>> PesquisarHorariosAgendamento(PesquisarAgendamentoViewModel pesquisar)
        {
            try
            {
                //var isAgendamento = _context.Agendamentos.Where(c => c.DataAgendamento.Equals(pesquisar.DataAgendamento)
                //                                                  && c.ProfissionalCpf.Equals(pesquisar.ProfissionalCpf));

                //if (isAgendamento.Any())
                //    throw new Exception($"Já existe agendamento para essa hora e profissional.");

                var nomeBarbearia = _context.Empresas.FirstOrDefaultAsync(p => p.Email.Equals(pesquisar.Email)).Result;

                var pesquisaAgendaEmpresa = new RetornoPesquisaAgendamentoViewModel()
                {
                    Email = pesquisar.Email,
                    NomeBarbearia = nomeBarbearia?.NomeBarbearia,
                };

                if (string.IsNullOrEmpty(pesquisar.ProfissionalCpf) || pesquisar.ProfissionalCpf == "Sem preferência")
                {
                    var profissionais = _context.Profissional.Where(p => p.EmpresaEmail.Equals(pesquisar.Email)).ToListAsync().Result;

                    if (profissionais != null)
                        foreach (var profissional in profissionais)
                            pesquisaAgendaEmpresa.Profissionais.Add(profissional);
                    else
                        throw new Exception($"Empresa não possui profissionais registrados!");

                }
                else
                {
                    var profissional = _context.Profissional.Where(c => c.Cpf.Equals(pesquisar.ProfissionalCpf)).FirstOrDefaultAsync().Result;

                    if (profissional != null)
                        pesquisaAgendaEmpresa.Profissionais.Add(profissional);
                    else
                        throw new Exception($"Empresa não possui profissionais registrados!");
                }

                //SqlParameter nomeBarbearia, cidade, uf;
                //nomeBarbearia = new SqlParameter("nomeBarbearia", $"{pesquisar.DataAgendamento}");
                //cidade = new SqlParameter("cidade", $"{pesquisar.Email}");
                //uf = new SqlParameter("uf", $"{pesquisar.ProfissionalCpf}");

                //var empresas = new List<Modelo.Modelos.Empresa>();

                //empresas = await _context.Empresas
                //    .FromSqlRaw($"SELECT TOP 100 * FROM dbo.Empresas " +
                //                            $"WHERE (@nomeBarbearia = '' or @nomeBarbearia is null or @nomeBarbearia like '%@nomeBarbearia%') " +
                //                            $"AND (@cidade = '' or @cidade is null or cidade = @cidade)" +
                //                            $"AND (@uf = '' or @uf is null or uf = @uf)", nomeBarbearia, cidade, uf).ToListAsync();



                //foreach (var emp in empresas)
                //{
                //    var empViewModel = new RetornoPesquisaEmpresasViewModel()
                //    {
                //        Email = emp.Email,
                //        NomeBarbearia = emp.NomeBarbearia,
                //        Celular = emp.Celular,
                //        Telefone = emp.Telefone,
                //        Cep = emp.Cep,
                //        Cidade = emp.Cidade,
                //        Complemento = emp.Complemento,
                //        Logradouro = emp.Logradouro,
                //        Numero = emp.Numero,
                //        UF = emp.UF
                //    };
                //    pesquisaAgendaEmpresa.Add(empViewModel);
                //}

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}
