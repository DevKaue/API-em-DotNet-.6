using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.APICOMPRAS.Domain.Entities;

namespace MP.APICOMPRAS.Infra.Data.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Chave Primaria e Nome da Tabela
            builder.ToTable("pessoa");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("idpessoa")
                .UseIdentityColumn();

            //Propriedades

            builder.Property(c => c.Document)
            .HasColumnName("documento");

            builder.Property(c => c.Name)
            .HasColumnName("nome");

            builder.Property(c => c.Cellphone)
            .HasColumnName("celular");

            //Chaves Secundarias

            builder.HasMany(c => c.Purchases)
                .WithOne(c => c.Person)
                .HasForeignKey(c => c.PersonId);

        }
    }
}