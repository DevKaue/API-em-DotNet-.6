using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.APICOMPRAS.Domain.Entities;

namespace MP.APICOMPRAS.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Chave Primaria e Nome da Tabela
            builder.ToTable("Product");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Idproduto")
                .UseIdentityColumn();

            //Propriedades

            builder.Property(c => c.CodErp)
            .HasColumnName("CodErp");

            builder.Property(c => c.Name)
            .HasColumnName("Nome");

            builder.Property(c => c.Price)
            .HasColumnName("Preco");

            //Chaves Secundarias

            builder.HasMany(c => c.Purchases)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId);
        }
    }
}