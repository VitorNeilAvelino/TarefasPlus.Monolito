using Microsoft.EntityFrameworkCore;
using TarefasPlus.Dominio.Entidades;

namespace TarefasPlus.Repositorios.SqlServer
{
    public class TaferasPlusDbContext : DbContext
    {
        public TaferasPlusDbContext(DbContextOptions opcoes) : base(opcoes)
        {
#if DEBUG
            Database.EnsureCreated();
#endif
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}