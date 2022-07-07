﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebGame.Database;

namespace WebGame.Database.Migrations
{
    [DbContext(typeof(WebGameDBContext))]
    [Migration("20220706075954_DeleteNew")]
    partial class DeleteNew
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WebGame.Database.Model.Hero", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BodyId")
                        .HasColumnType("integer");

                    b.Property<int>("HeadId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Sex")
                        .HasColumnType("boolean");

                    b.Property<int>("WeaponId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}