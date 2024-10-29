using Domain.Entities;
using Domain.Interfaces;
using Domain.Query;

[ExtendObjectType(Name = "Query")]
public class GetPessoaGraphQLQueryA
{
    private readonly IQueryHandler<GetPessoaQuery, GetPessoaQueryResponse> _queryHandler;

    public GetPessoaGraphQLQueryA(IQueryHandler<GetPessoaQuery, GetPessoaQueryResponse> queryHandler)
    {
        _queryHandler = queryHandler;
    }

    [GraphQLName("pessoaA")]
    public async Task<GetPessoaQueryResponse> GetPessoasAsync(
        [GraphQLType(typeof(StringType))] string? id = null) 
    {
        var query = new GetPessoaQuery("Consulta A", string.IsNullOrEmpty(id)? Guid.Empty : Guid.Parse(id)); 
        return await _queryHandler.Handle(query);
    }
}
