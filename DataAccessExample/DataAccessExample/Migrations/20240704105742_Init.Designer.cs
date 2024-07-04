﻿// <auto-generated />
using System;
using DataAccessExample.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessExample.Migrations
{
    [DbContext(typeof(ExampleDBContext))]
    [Migration("20240704105742_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccessExample.Entities.AnotherEntiry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateProperty")
                        .HasColumnType("datetime2");

                    b.Property<string>("StringProperty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnotherEnties");
                });

            modelBuilder.Entity("DataAccessExample.Entities.SampleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("AnotherProperty_Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateProperty")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("StringProperty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AnotherProperty_Id");

                    b.ToTable("SampleEntities");
                });

            modelBuilder.Entity("DataAccessExample.Entities.SampleEntity", b =>
                {
                    b.HasOne("DataAccessExample.Entities.AnotherEntiry", "AnotherProperty")
                        .WithMany("SampleEntities")
                        .HasForeignKey("AnotherProperty_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AnotherProperty");
                });

            modelBuilder.Entity("DataAccessExample.Entities.AnotherEntiry", b =>
                {
                    b.Navigation("SampleEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
