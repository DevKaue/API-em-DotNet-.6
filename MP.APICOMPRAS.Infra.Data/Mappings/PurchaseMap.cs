using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.APICOMPRAS.Domain.Entities;

namespace MP.APICOMPRAS.Infra.Data.Mappings
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            // Chave Primaria e Nome da Tabela
            builder.ToTable("Compra");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IdCompra")
                .UseIdentityColumn();

            //Propriedades

            builder.Property(c => c.PersonId)
            .HasColumnName("IdPessoa");

            builder.Property(c => c.ProductId)
            .HasColumnName("IdProduto");

            builder.Property(c => c.Date)
            .HasColumnName("DataCompra");

            //Chaves Secundarias

            builder.HasOne(c => c.Person)
                .WithMany(c => c.Purchases);


            builder.HasOne(c => c.Product)
            .WithMany(c => c.Purchases);

        }
    }
}