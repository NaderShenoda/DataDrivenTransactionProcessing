﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransactionProcessor.Api.Data;

namespace TransactionProcessor.Api.Migrations
{
    [DbContext(typeof(DataDefinitionContext))]
    partial class DataDefinitionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransactionProcessor.Entities.DataDefinition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsArray");

                    b.Property<long?>("MasterDataDefinitionId");

                    b.Property<string>("Name");

                    b.Property<long?>("ParentDataDefinitionId");

                    b.HasKey("Id");

                    b.ToTable("DataDefinitions");
                });

            modelBuilder.Entity("TransactionProcessor.Entities.ReferenceDataDefinition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ReferenceDataDefinitions");
                });

            modelBuilder.Entity("TransactionProcessor.Entities.ReferenceDataFieldDefinition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("ReferenceDataDefinitionId");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceDataDefinitionId");

                    b.ToTable("ReferenceDataFieldDefinitions");
                });

            modelBuilder.Entity("TransactionProcessor.Entities.ReferenceDataFieldInstance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ReferenceDataFieldDefinitionId");

                    b.Property<long>("ReferenceDataInstanceId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceDataFieldDefinitionId");

                    b.HasIndex("ReferenceDataInstanceId");

                    b.ToTable("ReferenceDataFieldInstances");
                });

            modelBuilder.Entity("TransactionProcessor.Entities.ReferenceDataInstance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ReferenceDataDefinitionId");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceDataDefinitionId");

                    b.ToTable("ReferenceDataInstances");
                });

            modelBuilder.Entity("TransactionProcessor.Entities.ReferenceDataFieldDefinition", b =>
                {
                    b.HasOne("TransactionProcessor.Entities.ReferenceDataDefinition", "ReferenceDataDefinition")
                        .WithMany("ReferenceDataFieldDefinitions")
                        .HasForeignKey("ReferenceDataDefinitionId");
                });

            modelBuilder.Entity("TransactionProcessor.Entities.ReferenceDataFieldInstance", b =>
                {
                    b.HasOne("TransactionProcessor.Entities.ReferenceDataFieldDefinition", "ReferenceDataFieldDefinition")
                        .WithMany("ReferenceDataFieldInstances")
                        .HasForeignKey("ReferenceDataFieldDefinitionId");

                    b.HasOne("TransactionProcessor.Entities.ReferenceDataInstance", "ReferenceDataInstance")
                        .WithMany("ReferenceDataFieldInstances")
                        .HasForeignKey("ReferenceDataInstanceId");
                });

            modelBuilder.Entity("TransactionProcessor.Entities.ReferenceDataInstance", b =>
                {
                    b.HasOne("TransactionProcessor.Entities.ReferenceDataDefinition", "ReferenceDataDefinition")
                        .WithMany("ReferenceDataInstances")
                        .HasForeignKey("ReferenceDataDefinitionId");
                });
#pragma warning restore 612, 618
        }
    }
}
