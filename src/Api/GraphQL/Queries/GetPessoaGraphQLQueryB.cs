using Domain.Entities;
using Domain.Interfaces;
using Domain.Query;

[ExtendObjectType(Name = "Query")]
public class GetPessoaGraphQLQueryB
{
    private readonly IQueryHandler<GetPessoaQuery, GetPessoaQueryResponse> _queryHandler;

    public GetPessoaGraphQLQueryB(IQueryHandler<GetPessoaQuery, GetPessoaQueryResponse> queryHandler)
    {
        _queryHandler = queryHandler;
    }

    [GraphQLName("pessoaB")]
    public async Task<GetPessoaQueryResponse> GetPessoasAsync(
        [GraphQLType(typeof(StringType))] string? id = null
        ) 
    {
        var query = new GetPessoaQuery("Consulta B", string.IsNullOrEmpty(id)? Guid.Empty : Guid.Parse(id)); 
        return await _queryHandler.Handle(query);
    }
}
