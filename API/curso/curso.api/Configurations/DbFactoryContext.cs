using curso.api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace curso.api.Configurations
{
    public class DbFactoryContext : IDesignTimeDbContextFactory<CursoDbContext>
    {
        public CursoDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<CursoDbContext>();
            options.UseSqlServer("Server=localhost;Database=CURSO;user=sa;password=App@223020");
            CursoDbContext contexto = new CursoDbContext(options);

            return contexto;
        }
    }
}
