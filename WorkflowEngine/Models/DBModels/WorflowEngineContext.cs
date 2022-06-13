using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorkflowEngine
{
    public partial class WorflowEngineContext : DbContext
    {
        public WorflowEngineContext()
        {
        }

        public WorflowEngineContext(DbContextOptions<WorflowEngineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttributeDB> Attributes { get; set; } = null!;
        public virtual DbSet<ConditionDB> Conditions { get; set; } = null!;
        public virtual DbSet<NextIdDB> NextIds { get; set; } = null!;
        public virtual DbSet<SchemeDB> Schemes { get; set; } = null!;
        public virtual DbSet<SchemePartDB> SchemeParts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WorflowEngine;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttributeDB>(entity =>
            {
                entity.HasKey(e => new { e.SchemeId, e.AttributeId });
            });

            modelBuilder.Entity<ConditionDB>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Condition1).HasColumnName("Condition");
            });

            modelBuilder.Entity<NextIdDB>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.NextId1).HasColumnName("NextId");
            });

            modelBuilder.Entity<SchemeDB>(entity =>
            {
                entity.Property(e => e.SchemeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<SchemePartDB>(entity =>
            {
                entity.HasKey(e => new { e.SchemeId, e.PartId });

                entity.Property(e => e.PartName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
