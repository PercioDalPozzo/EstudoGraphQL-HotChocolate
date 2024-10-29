namespace Domain.Entities;

public class Pessoa
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public DateTime Nascimento { get; set; }
    public string Celular { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    
    public DateTime Cadastro { get; set; } = DateTime.Now;
}