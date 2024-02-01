﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebNet.Models;

#nullable disable

namespace WebNet.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240201212243_changedDB")]
    partial class changedDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebNet.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotaObservacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoConsulta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorConsulta")
                        .HasColumnType("float");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
