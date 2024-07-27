using PosGraduacao.DesenvolvimentoAPIs.Models;

namespace PosGraduacao.DesenvolvimentoAPIs.Interfaces
{
    public interface IAlunoCadastro
    {
        public Aluno CriarAluno(Aluno aluno);
        public Aluno? RetornarAluno(int id);
    }
}
