﻿// <auto-generated />
using System;
using BookPubDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookPub.Migrations
{
    [DbContext(typeof(PublisherContext))]
    [Migration("20250305113151_updatePublisherContext")]
    partial class updatePublisherContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistCover", b =>
                {
                    b.Property<int>("ArtistsId")
                        .HasColumnType("int");

                    b.Property<int>("CoversId")
                        .HasColumnType("int");

                    b.HasKey("ArtistsId", "CoversId");

                    b.HasIndex("CoversId");

                    b.ToTable("ArtistCover");
                });

            modelBuilder.Entity("BookPubDB.Model.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("BookPubDB.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookPubDB.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookPubDB.Model.Cover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("DesignIdeas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DigitalOnly")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("Covers");
                });

            modelBuilder.Entity("ArtistCover", b =>
                {
                    b.HasOne("BookPubDB.Model.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookPubDB.Model.Cover", null)
                        .WithMany()
                        .HasForeignKey("CoversId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookPubDB.Model.Book", b =>
                {
                    b.HasOne("BookPubDB.Model.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BookPubDB.Model.Cover", b =>
                {
                    b.HasOne("BookPubDB.Model.Book", "Book")
                        .WithOne("Cover")
                        .HasForeignKey("BookPubDB.Model.Cover", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookPubDB.Model.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookPubDB.Model.Book", b =>
                {
                    b.Navigation("Cover")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
