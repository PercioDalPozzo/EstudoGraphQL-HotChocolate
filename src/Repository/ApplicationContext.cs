using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ApplicationContext : DbContext
{
    public DbSet<Pessoa> Pessoa { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
}