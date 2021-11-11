﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReadingTime.Data;

namespace ReadingTime.Migrations
{
    [DbContext(typeof(ReadingTimeContext))]
    partial class ReadingTimeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookMyGoalList", b =>
                {
                    b.Property<string>("BooksTitle")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ListsId")
                        .HasColumnType("int");

                    b.HasKey("BooksTitle", "ListsId");

                    b.HasIndex("ListsId");

                    b.ToTable("BookMyGoalList");
                });

            modelBuilder.Entity("ReadingTime.Models.Book", b =>
                {
                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Author")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.HasKey("Title");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("ReadingTime.Models.MyGoalList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("MyGoalList");
                });

            modelBuilder.Entity("ReadingTime.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BookTitle")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BookTitle");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BookMyGoalList", b =>
                {
                    b.HasOne("ReadingTime.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksTitle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReadingTime.Models.MyGoalList", null)
                        .WithMany()
                        .HasForeignKey("ListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReadingTime.Models.MyGoalList", b =>
                {
                    b.HasOne("ReadingTime.Models.User", "User")
                        .WithOne("MyGoalList")
                        .HasForeignKey("ReadingTime.Models.MyGoalList", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReadingTime.Models.User", b =>
                {
                    b.HasOne("ReadingTime.Models.Book", "Book")
                        .WithMany("Users")
                        .HasForeignKey("BookTitle");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("ReadingTime.Models.Book", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ReadingTime.Models.User", b =>
                {
                    b.Navigation("MyGoalList");
                });
#pragma warning restore 612, 618
        }
    }
}