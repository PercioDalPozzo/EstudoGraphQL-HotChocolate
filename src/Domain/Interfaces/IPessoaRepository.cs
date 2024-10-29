using Domain.Entities;

namespace Domain.Interfaces;

public interface IPessoaRepository
{
    Task<IReadOnlyList<Pessoa>> GetAll(Guid? id);
    void Add(Pessoa pessoa);
}