using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Infra.Data.EntityConfig
{
    public class LivroConfig : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnType("int")
                .UseIdentityColumn();
            builder.Property(p => p.Nome).HasColumnType("varchar(100)");
            builder.Property(p => p.IdUsuario);
            builder.Property(p => p.Disponivel);

            builder.Ignore(c => c.ValidationResult);

            //builder.HasOne(p => p.Usuario)
            //    .WithMany(u => u.Pedidos)
            //    .HasPrincipalKey(u => u.Id);
        }
    }
}
