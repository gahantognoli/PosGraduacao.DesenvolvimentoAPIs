using MessagePack;
using System.Text.Json;

Console.WriteLine("Lidando com JSON");

var dados = new Dados { Id = 1, Nome = "Teste Nome", Endereco = "Teste Endereço" };

Console.WriteLine(JsonSerializer.Serialize(dados));

Console.WriteLine(JsonSerializer.Serialize<Dados>(dados));

Console.WriteLine(JsonSerializer.Serialize(dados, options: new() { WriteIndented = true }));

var serializacao = MessagePackSerializer.Serialize(dados);
Console.WriteLine(serializacao);
Console.WriteLine(MessagePackSerializer.ConvertToJson(serializacao));

[MessagePackObject]
public class Dados
{
    [Key(0)]
    public int Id { get; set; }

    [Key(1)]
    public string? Nome { get; set; }

    [Key(2)]
    public string? Endereco { get; set; }
}