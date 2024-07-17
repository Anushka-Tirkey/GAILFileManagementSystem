﻿// <auto-generated />
using System;
using FILESMGMT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GAILFileManagementSystem.Migrations
{
    [DbContext(typeof(FileDBContext))]
    partial class FileDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FILESMGMT.Models.Contract", b =>
                {
                    b.Property<int>("sno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sno"), 1L, 1);

                    b.Property<string>("ContractDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContractType")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("sno");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("FILESMGMT.Models.Files", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"), 1L, 1);

                    b.Property<DateTime>("Closed_Date")
                        .HasColumnType("datetime")
                        .HasColumnName("Closed_Date");

                    b.Property<string>("ContractNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Contractsno")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Description");

                    b.Property<string>("FileName")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("File_Name");

                    b.Property<string>("File_type")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("File_Type");

                    b.Property<DateTime>("Open_Date")
                        .HasColumnType("datetime")
                        .HasColumnName("Open_Date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Status");

                    b.Property<string>("VendorAddress")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("vendoraddress");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("vendorname");

                    b.Property<int>("sno")
                        .HasColumnType("int");

                    b.HasKey("FileId");

                    b.HasIndex("Contractsno");

                    b.HasIndex("VendorId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("FILESMGMT.Models.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorId"), 1L, 1);

                    b.Property<string>("ContactEmailId")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("contactemail");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("contactno");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("contactperson");

                    b.Property<string>("VendorAddress")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("vendoraddress");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("vendorname");

                    b.HasKey("VendorId");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("FILESMGMT.Models.Files", b =>
                {
                    b.HasOne("FILESMGMT.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("Contractsno");

                    b.HasOne("FILESMGMT.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Vendor");
                });
#pragma warning restore 612, 618
        }
    }
}
