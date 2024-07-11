﻿// <auto-generated />
using System;
using FILESMGMT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FILESMGMT.Migrations.FileDB
{
    [DbContext(typeof(FileDBContext))]
    partial class FileDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FILESMGMT.Models.Files", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"), 1L, 1);

                    b.Property<DateTime>("Closed_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Contract_No")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Description");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("File_type")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("File Type");

                    b.Property<DateTime>("Open_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Status");

                    b.Property<string>("Vendor_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendor_name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("FileId");

                    b.ToTable("File", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
