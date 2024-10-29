using Domain.Interfaces;

namespace Domain.Query;

public class GetPessoaQueryHandler : IQueryHandler<GetPessoaQuery, GetPessoaQueryResponse>
{
    private readonly IPessoaRepository _pessoaRepository;
    
    public GetPessoaQueryHandler(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<GetPessoaQueryResponse> Handle(GetPessoaQuery query)
    {
        return new GetPessoaQueryResponse(query.OrigemConsulta, await _pessoaRepository.GetAll(query.Id));
    }
}