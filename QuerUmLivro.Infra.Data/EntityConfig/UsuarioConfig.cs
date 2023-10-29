using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Infra.Data.EntityConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnType("int")
                .UseIdentityColumn();
            builder.Property(p => p.Nome).HasColumnType("varchar(100)");
            builder.Property(p => p.Email).HasColumnType("varchar(100)");

            builder.HasMany(l => l.Interesses)
                .WithOne(i => i.Interessado)
                .HasForeignKey(l => l.InteressadoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.Livros)
                .WithOne(i => i.Doador)
                .HasForeignKey(l => l.DoadorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(c => c.ValidationResult);

        }
    }
}
