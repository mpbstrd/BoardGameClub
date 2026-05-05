using System;
using System.Collections.Generic;
using BoardGameClub.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGameClub.Infrastructure.Persistence;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<board_game> board_games { get; set; }

    public virtual DbSet<location> locations { get; set; }

    public virtual DbSet<mechanism> mechanisms { get; set; }

    public virtual DbSet<member> members { get; set; }

    public virtual DbSet<ownership> ownerships { get; set; }

    public virtual DbSet<play_session> play_sessions { get; set; }

    public virtual DbSet<play_session_participant> play_session_participants { get; set; }

    public virtual DbSet<rating> ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<board_game>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__board_ga__3213E83F01180E59");

            entity.ToTable("board_game");

            entity.HasIndex(e => e.name, "IX_board_game_name");

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.name).HasMaxLength(200);
            entity.Property(e => e.public_id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.weight).HasColumnType("decimal(3, 2)");

            entity.HasMany(d => d.mechanisms).WithMany(p => p.board_games)
                .UsingEntity<Dictionary<string, object>>(
                    "board_game_mechanism",
                    r => r.HasOne<mechanism>().WithMany()
                        .HasForeignKey("mechanism_id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__board_gam__mecha__6A30C649"),
                    l => l.HasOne<board_game>().WithMany()
                        .HasForeignKey("board_game_id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__board_gam__board__693CA210"),
                    j =>
                    {
                        j.HasKey("board_game_id", "mechanism_id").HasName("PK__board_ga__EC44D610A290371A");
                        j.ToTable("board_game_mechanisms");
                    });
        });

        modelBuilder.Entity<location>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__location__3213E83FD704B938");

            entity.Property(e => e.address).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(150);
            entity.Property(e => e.notes).HasMaxLength(500);
        });

        modelBuilder.Entity<mechanism>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__mechanis__3213E83FC7CD0956");

            entity.HasIndex(e => e.name, "UX_mechanisms_name").IsUnique();

            entity.Property(e => e.description).HasMaxLength(500);
            entity.Property(e => e.name).HasMaxLength(100);
        });

        modelBuilder.Entity<member>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__members__3213E83F2924CC02");

            entity.HasIndex(e => e.public_id, "UX_members_public_id").IsUnique();

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.public_id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.status).HasMaxLength(20);
        });

        modelBuilder.Entity<ownership>(entity =>
        {
            entity.HasKey(e => new { e.member_id, e.board_game_id }).HasName("PK__ownershi__496280B1FDFCB3FE");

            entity.ToTable("ownership");

            entity.Property(e => e.condition).HasMaxLength(50);
            entity.Property(e => e.notes).HasMaxLength(500);

            entity.HasOne(d => d.board_game).WithMany(p => p.ownerships)
                .HasForeignKey(d => d.board_game_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ownership__board__5FB337D6");

            entity.HasOne(d => d.member).WithMany(p => p.ownerships)
                .HasForeignKey(d => d.member_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ownership__membe__5EBF139D");
        });

        modelBuilder.Entity<play_session>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__play_ses__3213E83F39CF18B5");

            entity.HasIndex(e => e.play_date, "IX_play_sessions_date");

            entity.HasIndex(e => e.board_game_id, "IX_play_sessions_game");

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.notes).HasMaxLength(1000);
            entity.Property(e => e.public_id).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.board_game).WithMany(p => p.play_sessions)
                .HasForeignKey(d => d.board_game_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_play_sessions_board_game");

            entity.HasOne(d => d.location).WithMany(p => p.play_sessions)
                .HasForeignKey(d => d.location_id)
                .HasConstraintName("FK_play_sessions_location");
        });

        modelBuilder.Entity<play_session_participant>(entity =>
        {
            entity.HasKey(e => new { e.play_session_id, e.member_id }).HasName("PK__play_ses__E49BF0359748484F");

            entity.HasOne(d => d.member).WithMany(p => p.play_session_participants)
                .HasForeignKey(d => d.member_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_psp_member");

            entity.HasOne(d => d.play_session).WithMany(p => p.play_session_participants)
                .HasForeignKey(d => d.play_session_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_psp_session");
        });

        modelBuilder.Entity<rating>(entity =>
        {
            entity.HasKey(e => new { e.member_id, e.board_game_id }).HasName("PK__ratings__496280B181672985");

            entity.Property(e => e.rated_at).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.rating1)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("rating");
            entity.Property(e => e.review).HasMaxLength(1000);

            entity.HasOne(d => d.board_game).WithMany(p => p.ratings)
                .HasForeignKey(d => d.board_game_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ratings__board_g__6477ECF3");

            entity.HasOne(d => d.member).WithMany(p => p.ratings)
                .HasForeignKey(d => d.member_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ratings__member___6383C8BA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
