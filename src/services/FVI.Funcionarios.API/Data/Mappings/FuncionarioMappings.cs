using FVI.Core.DomainObjects;
using FVI.Funcionarios.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FVI.Funcionarios.API.Data.Mappings
{
    public class FuncionarioMappings : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(c => c.Cpf, d =>
            {
                d.Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(Cpf.CpfTamanhoMaximo)
                .HasColumnName("Cpf")
                .HasColumnType($"varchar({Cpf.CpfTamanhoMaximo})");
            });

            builder.OwnsOne(c => c.Email, d =>
            {
                d.Property(c => c.Endereco)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"varchar({ Email.EnderecoTamanhoMaximo })");
            });

            builder.HasOne(c => c.Endereco)
                .WithOne(c => c.Funcionario);

            builder.ToTable("Funcionarios");
        }
    }
}