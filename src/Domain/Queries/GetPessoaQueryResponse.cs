using Domain.Entities;

namespace Domain.Query;

public record GetPessoaQueryResponse(string OrigemConsulta, IReadOnlyList<Pessoa> Records ){ }