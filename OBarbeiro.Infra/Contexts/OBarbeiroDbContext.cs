using Microsoft.EntityFrameworkCore;
using OBarbeiro.Infra.EntityConfigurations;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.Contexts;
public partial class OBarbeiroDbContext : DbContext
{
    public OBarbeiroDbContext(DbContextOptions<OBarbeiroDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Empresa> Empresas { get; set; }

    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<AgendamentoStatus> AgendamentoStatus { get; set; }

    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Profissional> Profissional { get; set; }
    public DbSet<AgendaProfissional> AgendaProfissional { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging(true);
        optionsBuilder.UseLazyLoadingProxies(false);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Schema 
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.ApplyConfiguration(new AgendamentoEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AgendamentoStatusEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AgendaProfissionalEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new EmpresaEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PerfilUsuarioEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProfissionalEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ServicoEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioEntityTypeConfiguration());
    }
}
