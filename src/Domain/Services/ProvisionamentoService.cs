using Bogus;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services;

public class ProvisionamentoService : IProvisionamentoService 
{
    private readonly IPessoaRepository _pessoaRepository;
    
    public ProvisionamentoService(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }
    
    public void Provisionar()
    {
        var fakes = new Faker<Pessoa>()
            .RuleFor(p=>p.Nome,f=>f.Person.FirstName)
            .RuleFor(p=>p.Nascimento,f=>f.Date.Past())
            .RuleFor(p=>p.Celular,f=>f.Phone.PhoneNumber())
            .RuleFor(p=>p.Documento,f=>f.Lorem.Sentence())
            .Generate(3);

        foreach (var pessoa in fakes)
        {
            _pessoaRepository.Add(pessoa);
        }
    }
}