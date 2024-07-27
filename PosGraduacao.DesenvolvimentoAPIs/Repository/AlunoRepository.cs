using PosGraduacao.DesenvolvimentoAPIs.Interfaces;
using PosGraduacao.DesenvolvimentoAPIs.Models;

namespace PosGraduacao.DesenvolvimentoAPIs.Repository
{
    public class AlunoRepository : IAlunoCadastro
    {
        public IList<Aluno> Alunos { get; set; }

        public AlunoRepository()
        {
            Alunos = new List<Aluno>();
        }

        public Aluno CriarAluno(Aluno aluno)
        {
            aluno.Id = Alunos.Any() ? Alunos.Select(x => x.Id).Max() + 1 : 1;
            Alunos.Add(aluno);
            return aluno;
        }

        public Aluno? RetornarAluno(int id)
        {
            throw new NotImplementedException();
        }
    }
}
