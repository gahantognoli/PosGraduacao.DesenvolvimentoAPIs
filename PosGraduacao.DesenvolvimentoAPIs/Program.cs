using PosGraduacao.DesenvolvimentoAPIs.Implementations;
using PosGraduacao.DesenvolvimentoAPIs.Interfaces;
using PosGraduacao.DesenvolvimentoAPIs.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBancoDados, BancoDados>();
builder.Services.AddScoped<IAlunoCadastro, AlunoCadastro>();
builder.Services.AddKeyedScoped<IAlunoCadastro, AlunoCadastro>("Forma2");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration()
{
    LogLevel = LogLevel.Information,
}));

//builder.Services.AddSingleton<IAlunoCadastro, AlunoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
