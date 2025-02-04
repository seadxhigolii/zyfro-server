﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Zyfro.Pro.Server.Persistence;

#nullable disable

namespace Zyfro.Pro.Server.Persistence.Migrations
{
    [DbContext(typeof(ProDbContext))]
    partial class ProDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("Deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedAtUtc");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("FailedLoginAttempts")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("LastUpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdatedAtUtc");

                    b.Property<DateTime?>("LockoutEndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("ApplicationUsers", "public");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.AuditLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("Deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedAtUtc");

                    b.Property<Guid?>("DocumentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdatedAtUtc");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AuditLogs", "public");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("Deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedAtUtc");

                    b.Property<DateTime>("LastUpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdatedAtUtc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Company", "public");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("Deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedAtUtc");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdatedAtUtc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Documents", "public");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.DocumentTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("Deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedAtUtc");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdatedAtUtc");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("DocumentTags", "public");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.DocumentVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("Deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedAtUtc");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdatedAtUtc");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("VersionNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("DocumentVersions", "public");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("Deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedAtUtc");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdatedAtUtc");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications", "public");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.SignatureRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("Deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedAtUtc");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsSigned")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdatedAtUtc");

                    b.Property<Guid>("RequestedById")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RequestedToId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("SignedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("RequestedById");

                    b.HasIndex("RequestedToId");

                    b.ToTable("SignatureRequests", "public");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.Workflow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("Deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedAtUtc");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdatedAtUtc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("Workflows", "public");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.WorkflowStep", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid?>("AssignedToUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean")
                        .HasColumnName("Deleted");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedAtUtc");

                    b.Property<DateTime>("LastUpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdatedAtUtc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("StepNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToUserId");

                    b.HasIndex("WorkflowId");

                    b.ToTable("WorkflowSteps", "public");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.Company", "Company")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.AuditLog", b =>
                {
                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.Document", b =>
                {
                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.ApplicationUser", "Owner")
                        .WithMany("Documents")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.DocumentTag", b =>
                {
                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.Document", "Document")
                        .WithMany("Tags")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.DocumentVersion", b =>
                {
                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.Document", "Document")
                        .WithMany("Versions")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.Notification", b =>
                {
                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.SignatureRequest", b =>
                {
                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.ApplicationUser", "RequestedBy")
                        .WithMany()
                        .HasForeignKey("RequestedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.ApplicationUser", "RequestedTo")
                        .WithMany()
                        .HasForeignKey("RequestedToId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("RequestedBy");

                    b.Navigation("RequestedTo");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.Workflow", b =>
                {
                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.Document", "Document")
                        .WithMany("Workflows")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.WorkflowStep", b =>
                {
                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.ApplicationUser", "AssignedToUser")
                        .WithMany()
                        .HasForeignKey("AssignedToUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Zyfro.Pro.Server.Domain.Entities.Workflow", "Workflow")
                        .WithMany("Steps")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedToUser");

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.Company", b =>
                {
                    b.Navigation("ApplicationUsers");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.Document", b =>
                {
                    b.Navigation("Tags");

                    b.Navigation("Versions");

                    b.Navigation("Workflows");
                });

            modelBuilder.Entity("Zyfro.Pro.Server.Domain.Entities.Workflow", b =>
                {
                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}
