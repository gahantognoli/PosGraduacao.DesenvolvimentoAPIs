using Microsoft.AspNetCore.Mvc;
using PosGraduacao.DesenvolvimentoAPIs.Interfaces;
using PosGraduacao.DesenvolvimentoAPIs.Models;

namespace PosGraduacao.DesenvolvimentoAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAlunoCadastro _alunoCadastro;
        private readonly ILogger<AtendimentoController> _logger;

        public AtendimentoController(IAlunoCadastro alunoCadastro, ILogger<AtendimentoController> logger)
        {
            _alunoCadastro = alunoCadastro;
            _logger = logger;
        }

        [HttpGet("aluno")]
        public IActionResult GetAluno(IServiceProvider serviceProvider, int id)
        {
            var alunoCadastro = serviceProvider.GetRequiredService<IAlunoCadastro>();
            _logger.LogInformation("Teste de log do tipo information");
            return Ok(alunoCadastro.RetornarAluno(id));
        }

        [HttpPost("criar-aluno")]
        public IActionResult CriarAluno([FromKeyedServices("Forma2")] IAlunoCadastro alunoCadastro, Aluno aluno)
        {
            return Ok(alunoCadastro.CriarAluno(aluno));
        }
    }
}
