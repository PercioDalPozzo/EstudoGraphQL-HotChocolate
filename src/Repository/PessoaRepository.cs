using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class PessoaRepository : IPessoaRepository
{
    private readonly ApplicationContext _context;

    public PessoaRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Pessoa>> GetAll(Guid? id)
    {
        var query =  _context.Pessoa.AsQueryable();
        
        if (id != Guid.Empty)
            query = query.Where(p => p.Id == id);   
        
        return await query.ToListAsync();
    }
    
    public void Add(Pessoa pessoa)
    {
        _context.Pessoa.Add(pessoa);
        _context.SaveChanges();
    }
}