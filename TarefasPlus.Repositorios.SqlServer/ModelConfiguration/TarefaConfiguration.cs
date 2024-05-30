using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TarefasPlus.Dominio.Entidades;

namespace TarefasPlus.Repositorios.SqlServer
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable(nameof(Tarefa));
            builder.Property(t => t.Descricao).HasMaxLength(500);
        }
    }
}