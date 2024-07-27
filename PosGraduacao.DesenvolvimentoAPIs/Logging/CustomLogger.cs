
namespace PosGraduacao.DesenvolvimentoAPIs.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _loggerConfig;

        public static bool Arquivo { get; set; } = false;

        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig)
        {
            _loggerName = loggerName;
            _loggerConfig = loggerConfig;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var mensagem = $"Log de execução: {logLevel}: {eventId} - {formatter(state, exception)}";

            if (Arquivo)
                EscreverArquivo(mensagem);
            else
                Console.WriteLine(mensagem);
        }

        private void EscreverArquivo(string mensagem)
        {
            var caminhoArquivo = Path.Combine(Environment.CurrentDirectory, $"log-{DateTime.Now:yyyy-MM-dd}.txt");
            if (!File.Exists(caminhoArquivo))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(caminhoArquivo)!);
                File.Create(caminhoArquivo).Dispose();
            }

            using StreamWriter streamWriter = new(caminhoArquivo, true);
            streamWriter.WriteLine(mensagem);
            streamWriter.Close();
        }
    }
}
