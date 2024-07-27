using System.Collections.Concurrent;

namespace PosGraduacao.DesenvolvimentoAPIs.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly CustomLoggerProviderConfiguration _loggerConfig;
        private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new();

        public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig)
        {
            _loggerConfig = loggerConfig;
        }

        public ILogger CreateLogger(string categoryName) 
            => _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _loggerConfig));

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
