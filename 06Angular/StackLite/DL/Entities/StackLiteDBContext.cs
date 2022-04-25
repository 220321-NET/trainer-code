using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL.Entities
{
    public partial class StackLiteDBContext : DbContext
    {
        public StackLiteDBContext()
        {
        }

        public StackLiteDBContext(DbContextOptions<StackLiteDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Issue> Issues { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsBestAnswer).HasDefaultValueSql("((0))");

                entity.Property(e => e.Score).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Answers__AuthorI__6754599E");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.IssueId)
                    .HasConstraintName("FK__Answers__IssueId__693CA210");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsClosed).HasDefaultValueSql("((0))");

                entity.Property(e => e.Score).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Issues__AuthorId__628FA481");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Bio).IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
