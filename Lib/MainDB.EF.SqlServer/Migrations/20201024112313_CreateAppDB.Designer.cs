﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XTI_DB;

namespace MainDB.EF.SqlServer
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20201024112313_CreateAppDB")]
    partial class CreateAppDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XTI_DB.Entities.AppEventRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(32000);

                    b.Property<string>("EventKey")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.Property<int>("Severity")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOccurred")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("EventKey")
                        .IsUnique()
                        .HasFilter("[EventKey] IS NOT NULL");

                    b.HasIndex("RequestID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("XTI_DB.Entities.AppRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("TimeAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .HasDefaultValue("");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("XTI_DB.Entities.AppRequestRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModifierID")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("RequestKey")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ResourceID")
                        .HasColumnType("int");

                    b.Property<int>("SessionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeEnded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStarted")
                        .HasColumnType("datetime2");

                    b.Property<int>("VersionID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ModifierID");

                    b.HasIndex("RequestKey")
                        .IsUnique()
                        .HasFilter("[RequestKey] IS NOT NULL");

                    b.HasIndex("ResourceID");

                    b.HasIndex("SessionID");

                    b.HasIndex("VersionID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("XTI_DB.Entities.AppRoleRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("AppID", "Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("XTI_DB.Entities.AppSessionRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RemoteAddress")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("RequesterKey")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SessionKey")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("TimeEnded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStarted")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SessionKey")
                        .IsUnique()
                        .HasFilter("[SessionKey] IS NOT NULL");

                    b.HasIndex("UserID");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("XTI_DB.Entities.AppUserModifierRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModifierID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ModifierID");

                    b.HasIndex("UserID");

                    b.ToTable("UserModifiers");
                });

            modelBuilder.Entity("XTI_DB.Entities.AppUserRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("TimeAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("XTI_DB.Entities.AppUserRoleRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("XTI_DB.Entities.AppVersionRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Major")
                        .HasColumnType("int");

                    b.Property<int>("Minor")
                        .HasColumnType("int");

                    b.Property<int>("Patch")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeAdded")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VersionKey")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("AppID");

                    b.HasIndex("VersionKey")
                        .IsUnique()
                        .HasFilter("[VersionKey] IS NOT NULL");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("XTI_DB.Entities.ModifierCategoryAdminRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.HasIndex("ModCategoryID", "UserID")
                        .IsUnique();

                    b.ToTable("ModifierCategoryAdmins");
                });

            modelBuilder.Entity("XTI_DB.Entities.ModifierCategoryRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("AppID", "Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("ModifierCategories");
                });

            modelBuilder.Entity("XTI_DB.Entities.ModifierRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("DisplayText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("ModKey")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("TargetKey")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("ModKey")
                        .IsUnique()
                        .HasFilter("[ModKey] IS NOT NULL");

                    b.HasIndex("CategoryID", "TargetKey")
                        .IsUnique()
                        .HasFilter("[TargetKey] IS NOT NULL");

                    b.ToTable("Modifiers");
                });

            modelBuilder.Entity("XTI_DB.Entities.ResourceGroupRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppID")
                        .HasColumnType("int");

                    b.Property<int>("ModCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("ModCategoryID");

                    b.HasIndex("AppID", "Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("ResourceGroups");
                });

            modelBuilder.Entity("XTI_DB.Entities.ResourceRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("GroupID", "Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("XTI_DB.Entities.AppEventRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.AppRequestRecord", null)
                        .WithMany()
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.AppRequestRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.ModifierRecord", null)
                        .WithMany()
                        .HasForeignKey("ModifierID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("XTI_DB.Entities.ResourceRecord", null)
                        .WithMany()
                        .HasForeignKey("ResourceID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("XTI_DB.Entities.AppSessionRecord", null)
                        .WithMany()
                        .HasForeignKey("SessionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("XTI_DB.Entities.AppVersionRecord", null)
                        .WithMany()
                        .HasForeignKey("VersionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.AppRoleRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.AppRecord", null)
                        .WithMany()
                        .HasForeignKey("AppID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.AppSessionRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.AppUserRecord", null)
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.AppUserModifierRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.ModifierRecord", null)
                        .WithMany()
                        .HasForeignKey("ModifierID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("XTI_DB.Entities.AppUserRecord", null)
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.AppUserRoleRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.AppRoleRecord", null)
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("XTI_DB.Entities.AppUserRecord", null)
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.AppVersionRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.AppRecord", null)
                        .WithMany()
                        .HasForeignKey("AppID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.ModifierCategoryAdminRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.ModifierCategoryRecord", null)
                        .WithMany()
                        .HasForeignKey("ModCategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("XTI_DB.Entities.AppUserRecord", null)
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.ModifierCategoryRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.AppRecord", null)
                        .WithMany()
                        .HasForeignKey("AppID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.ModifierRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.ModifierCategoryRecord", null)
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.ResourceGroupRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.AppRecord", null)
                        .WithMany()
                        .HasForeignKey("AppID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("XTI_DB.Entities.ModifierCategoryRecord", null)
                        .WithMany()
                        .HasForeignKey("ModCategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_DB.Entities.ResourceRecord", b =>
                {
                    b.HasOne("XTI_DB.Entities.ResourceGroupRecord", null)
                        .WithMany()
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
