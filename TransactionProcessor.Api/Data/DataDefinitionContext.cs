using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionProcessor.Entities;

namespace TransactionProcessor.Api.Data
{
    public partial class DataDefinitionContext : DbContext
    {
        public virtual DbSet<DataDefinition> DataDefinitions { get; set; }

        public virtual DbSet<ReferenceDataDefinition> ReferenceDataDefinitions { get; set; }
        public virtual DbSet<ReferenceDataFieldDefinition> ReferenceDataFieldDefinitions { get; set; }
        public virtual DbSet<ReferenceDataInstance> ReferenceDataInstances { get; set; }
        public virtual DbSet<ReferenceDataFieldInstance> ReferenceDataFieldInstances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DataDefinitions;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReferenceDataDefinition>(builder =>
            {
                builder.HasMany(definition => definition.ReferenceDataFieldDefinitions)
                .WithOne(definition => definition.ReferenceDataDefinition)
                .HasForeignKey(definition => definition.ReferenceDataDefinitionId)
                .HasPrincipalKey(definition => definition.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ReferenceDataFieldInstance>(builder =>
            {
                builder.HasOne(definition => definition.ReferenceDataFieldDefinition)
                .WithMany()
                .HasForeignKey(definition => definition.ReferenceDataFieldDefinitionId)
                .HasPrincipalKey(definition => definition.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ReferenceDataInstance>(builder =>
            {
                builder.HasMany(instance => instance.ReferenceDataFieldInstances)
                .WithOne(instance => instance.ReferenceDataInstance)
                .HasForeignKey(instance => instance.ReferenceDataInstanceId)
                .HasPrincipalKey(instance => instance.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);

                builder.HasOne(definition => definition.ReferenceDataDefinition)
                    .WithMany()
                    .HasForeignKey(definition => definition.ReferenceDataDefinitionId)
                    .HasPrincipalKey(definition => definition.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });
        }
    }
}
