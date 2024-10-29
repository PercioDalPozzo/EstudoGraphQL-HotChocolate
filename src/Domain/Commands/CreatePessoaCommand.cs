namespace Domain.Command;

public class CreatePessoaCommand
{
    public string Nome { get; set; } = String.Empty;
    public DateTime Nascimento { get; set; }
}