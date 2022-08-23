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
    [Migration("20220823133019_SessionAdd2")]
    partial class SessionAdd2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WebGame.Database.Model.Ammunition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("HeroClass")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Race")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Ammunition");
                });

            modelBuilder.Entity("WebGame.Database.Model.Hero", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActionPoints")
                        .HasColumnType("integer");

                    b.Property<Guid>("BodyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HeadId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HelmetId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDead")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("RaceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SecondWeaponId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Sex")
                        .HasColumnType("boolean");

                    b.Property<bool>("ShowHelmet")
                        .HasColumnType("boolean");

                    b.Property<Guid>("SpecializationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WeaponId")
                        .HasColumnType("uuid");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("WebGame.Database.Model.Race", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("WebGame.Database.Model.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebGame.Database.Model.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BaseStat")
                        .HasColumnType("text");

                    b.Property<int?>("BonusActionPoints")
                        .HasColumnType("integer");

                    b.Property<int?>("CostActionPoints")
                        .HasColumnType("integer");

                    b.Property<int?>("DamageRadius")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsOnAlly")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("RaceId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Range")
                        .HasColumnType("integer");

                    b.Property<int?>("RechargeTime")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SpecializationId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid?>("TargetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("WebGame.Database.Model.Specialization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("WebGame.Database.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebGame.Database.Model.UserSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserRoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("WebGame.Database.Model.Hero", b =>
                {
                    b.HasOne("WebGame.Database.Model.Race", "Race")
                        .WithMany("Hero")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebGame.Database.Model.Specialization", "Specialization")
                        .WithMany("Hero")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("WebGame.Database.Model.Skill", b =>
                {
                    b.HasOne("WebGame.Database.Model.Race", null)
                        .WithMany("Skills")
                        .HasForeignKey("RaceId");

                    b.HasOne("WebGame.Database.Model.Specialization", null)
                        .WithMany("Skills")
                        .HasForeignKey("SpecializationId");
                });

            modelBuilder.Entity("WebGame.Database.Model.User", b =>
                {
                    b.HasOne("WebGame.Database.Model.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebGame.Database.Model.UserSession", b =>
                {
                    b.HasOne("WebGame.Database.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebGame.Database.Model.Role", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("WebGame.Database.Model.Race", b =>
                {
                    b.Navigation("Hero");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("WebGame.Database.Model.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebGame.Database.Model.Specialization", b =>
                {
                    b.Navigation("Hero");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
