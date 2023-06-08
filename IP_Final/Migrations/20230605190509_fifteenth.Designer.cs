﻿// <auto-generated />
using IP_Final.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IP_Final.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230605190509_fifteenth")]
    partial class fifteenth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IP_Final.Models.Domain.DenemeTable", b =>
                {
                    b.Property<int>("deneme_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("deneme_id"));

                    b.Property<string>("deneme_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("deneme_id");

                    b.ToTable("DenemeTables");
                });

            modelBuilder.Entity("IP_Final.Models.Domain.Software", b =>
                {
                    b.Property<int>("app_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("app_id"));

                    b.Property<string>("app_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("app_image_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("app_install_count")
                        .HasColumnType("int");

                    b.Property<string>("app_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("app_owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("app_size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("app_version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cat_code")
                        .HasColumnType("int");

                    b.Property<int>("lang_code")
                        .HasColumnType("int");

                    b.Property<int>("os_code")
                        .HasColumnType("int");

                    b.HasKey("app_id");

                    b.ToTable("Softwares");
                });
#pragma warning restore 612, 618
        }
    }
}