namespace OBarbeiro.Negocio.NegocioBase;
public interface INegocioBase<T> where T : class
{
    Task<List<T>> ObterTodos();
    Task<T> Obter(params object[] valor);
    Task<T> Incluir(T objeto);
    Task<T> Alterar(T objeto);
    void ExlcuirObjeto(T objeto);
    void Excluir(params object[] valor);
    void SaveChages();
}
