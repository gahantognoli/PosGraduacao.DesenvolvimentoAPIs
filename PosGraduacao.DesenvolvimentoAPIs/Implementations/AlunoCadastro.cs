using PosGraduacao.DesenvolvimentoAPIs.Interfaces;
using PosGraduacao.DesenvolvimentoAPIs.Models;

namespace PosGraduacao.DesenvolvimentoAPIs.Implementations
{
    public class AlunoCadastro : IAlunoCadastro
    {
        private readonly IBancoDados _bancoDados;

        public AlunoCadastro(IBancoDados bancoDados)
        {
            _bancoDados = bancoDados;
        }

        public Aluno CriarAluno(Aluno aluno)
        {
            _bancoDados.Inserir(aluno);
            return aluno;
        }

        public Aluno? RetornarAluno(int id)
        {
            return _bancoDados.Retornar(id) as Aluno;
        }
    }
}
