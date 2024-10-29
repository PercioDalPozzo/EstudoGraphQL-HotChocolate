using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Command;

public class CreatePessoaCommandHandler : ICommandHandler<CreatePessoaCommand, CreatePessoaCommandResponse>
{
    private readonly IPessoaRepository _pessoaRepository;
    
    public CreatePessoaCommandHandler(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<CreatePessoaCommandResponse> Handle(CreatePessoaCommand command)
    {
        var novo = new Pessoa()
        {
            Nome = command.Nome,
            Nascimento = command.Nascimento
        };
        
        _pessoaRepository.Add(novo);

        return new CreatePessoaCommandResponse(novo.Id);
    }
}