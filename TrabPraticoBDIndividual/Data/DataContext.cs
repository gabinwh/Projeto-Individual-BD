using Microsoft.EntityFrameworkCore;
using TrabPraticoBDIndividual.Entities;

namespace TrabPraticoBDIndividual.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }

}
