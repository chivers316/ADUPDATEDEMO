﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StringCounterDemo.Data;

#nullable disable

namespace StringCounterDemo.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230407195815_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("StringCounterDemo.Models.Strings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("InputString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OutputString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("strings");
                });
#pragma warning restore 612, 618
        }
    }
}
