using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoClientes.Infrastructure.EntityModels.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(c => c.Cpf)
            .IsRequired()
            .HasColumnType("varchar(11)");

            builder.Property(c => c.Endereco)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(c => c.Estado)
             .IsRequired()
             .HasColumnType("varchar(2)");

            builder.Property(c => c.Cidade)
             .IsRequired()
             .HasColumnType("varchar(100)");

            builder.ToTable("CLIENTE");
        }
    }
}
