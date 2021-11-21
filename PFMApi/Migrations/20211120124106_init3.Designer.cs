﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PFMApi.Database;

namespace PFMApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211120124106_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PFMApi.Database.Entity.Categories", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ParentCode")
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PFMApi.Database.Entity.MmcCodes", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MerchantType")
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("MccCodes");
                });

            modelBuilder.Entity("PFMApi.Database.Entity.Transactions", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("BeneficiaryName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("CategoryCode")
                        .HasColumnType("text");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Kind")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Mcc")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
