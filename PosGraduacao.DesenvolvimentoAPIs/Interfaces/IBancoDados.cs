namespace PosGraduacao.DesenvolvimentoAPIs.Interfaces
{
    public interface IBancoDados
    {
        int Inserir<T>(T obj);
        object Retornar(int id);
    }
}
