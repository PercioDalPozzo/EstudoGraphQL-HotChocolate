using Domain.Command;
using Domain.Interfaces;

[ExtendObjectType(Name = "Mutation")]
public class CreatePessoaGraphQLMutation
{
    private readonly ICommandHandler<CreatePessoaCommand, CreatePessoaCommandResponse> _createPessoaHandler;

    public CreatePessoaGraphQLMutation(ICommandHandler<CreatePessoaCommand, CreatePessoaCommandResponse> createPessoaHandler)
    {
        _createPessoaHandler = createPessoaHandler;
    }

    [GraphQLName("createPessoa")]
    public async Task<CreatePessoaCommandResponse> CreatePessoaAsync(CreatePessoaCommand input)
    {
        return await _createPessoaHandler.Handle(input);
    }
}