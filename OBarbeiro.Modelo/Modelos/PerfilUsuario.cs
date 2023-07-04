namespace OBarbeiro.Modelo.Modelos;
public class PerfilUsuario
{
    public int PerfilUsuarioId { get; set; }
    public string Perfil { get; set; }
    public string Descricao { get; set; }


    public Usuario? Usuario { get; set; }
}
