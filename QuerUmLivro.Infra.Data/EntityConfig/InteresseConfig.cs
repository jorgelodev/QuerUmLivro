using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Infra.Data.EntityConfig
{
    internal class InteresseConfig : IEntityTypeConfiguration<Interesse>
    {
        public void Configure(EntityTypeBuilder<Interesse> builder)
        {
            builder.ToTable("Interesse");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnType("int")
                .UseIdentityColumn();
            builder.Property(p => p.Justificativa).HasColumnType("varchar(100)");
            builder.Property(p => p.InteressadoId);
            builder.Property(p => p.LivroId);
            builder.Property(p => p.Aprovado);
            builder.Property(p => p.Data);

            builder.HasOne(i => i.Livro)
                .WithMany(l => l.Interesses)
                .HasPrincipalKey(i => i.Id);

            builder.Ignore(c => c.ValidationResult);
        }
    }
}
