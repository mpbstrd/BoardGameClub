using System;
using System.Collections.Generic;
using BoardGameClub.Infrastructure.Persistence.Scaffolded;
using Microsoft.EntityFrameworkCore;

namespace BoardGameClub.Infrastructure.Persistence;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BoardGame> BoardGames { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Mechanism> Mechanisms { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Ownership> Ownerships { get; set; }

    public virtual DbSet<PlaySession> PlaySessions { get; set; }

    public virtual DbSet<PlaySessionParticipant> PlaySessionParticipants { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BoardGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__board_ga__3213E83F01180E59");

            entity.ToTable("board_game");

            entity.HasIndex(e => e.Name, "IX_board_game_name");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BggId).HasColumnName("bgg_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.MaxPlayers).HasColumnName("max_players");
            entity.Property(e => e.MinPlayers).HasColumnName("min_players");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.PublicId)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("public_id");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("weight");

            entity.HasMany(d => d.Publishers).WithMany(p => p.BoardGames)
                .UsingEntity<Dictionary<string, object>>(
                    "BoardGamePublisher",
                    r => r.HasOne<Publisher>().WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__board_gam__publi__07C12930"),
                    l => l.HasOne<BoardGame>().WithMany()
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__board_gam__board__06CD04F7"),
                    j =>
                    {
                        j.HasKey("BoardGameId", "PublisherId").HasName("PK__board_ga__7CB66777278E6D1D");
                        j.ToTable("board_game_publishers");
                        j.IndexerProperty<int>("BoardGameId").HasColumnName("board_game_id");
                        j.IndexerProperty<int>("PublisherId").HasColumnName("publisher_id");
                    });
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__location__3213E83FD704B938");

            entity.ToTable("locations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
        });

        modelBuilder.Entity<Mechanism>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mechanis__3213E83FC7CD0956");

            entity.ToTable("mechanisms");

            entity.HasIndex(e => e.Name, "UX_mechanisms_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__members__3213E83F2924CC02");

            entity.ToTable("members");

            entity.HasIndex(e => e.PublicId, "UX_members_public_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PublicId)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("public_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<Ownership>(entity =>
        {
            entity.HasKey(e => new { e.MemberId, e.BoardGameId }).HasName("PK__ownershi__496280B1FDFCB3FE");

            entity.ToTable("ownership");

            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.BoardGameId).HasColumnName("board_game_id");
            entity.Property(e => e.AcquiredDate).HasColumnName("acquired_date");
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .HasColumnName("condition");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");

            entity.HasOne(d => d.BoardGame).WithMany(p => p.Ownerships)
                .HasForeignKey(d => d.BoardGameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ownership__board__5FB337D6");

            entity.HasOne(d => d.Member).WithMany(p => p.Ownerships)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ownership__membe__5EBF139D");
        });

        modelBuilder.Entity<PlaySession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__play_ses__3213E83F39CF18B5");

            entity.ToTable("play_sessions");

            entity.HasIndex(e => e.PlayDate, "IX_play_sessions_date");

            entity.HasIndex(e => e.BoardGameId, "IX_play_sessions_game");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BoardGameId).HasColumnName("board_game_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .HasColumnName("notes");
            entity.Property(e => e.PlayDate).HasColumnName("play_date");
            entity.Property(e => e.PublicId)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("public_id");

            entity.HasOne(d => d.BoardGame).WithMany(p => p.PlaySessions)
                .HasForeignKey(d => d.BoardGameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_play_sessions_board_game");

            entity.HasOne(d => d.Location).WithMany(p => p.PlaySessions)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_play_sessions_location");
        });

        modelBuilder.Entity<PlaySessionParticipant>(entity =>
        {
            entity.HasKey(e => new { e.PlaySessionId, e.MemberId }).HasName("PK__play_ses__E49BF0359748484F");

            entity.ToTable("play_session_participants");

            entity.Property(e => e.PlaySessionId).HasColumnName("play_session_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.IsWinner).HasColumnName("is_winner");
            entity.Property(e => e.Placement).HasColumnName("placement");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.Member).WithMany(p => p.PlaySessionParticipants)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_psp_member");

            entity.HasOne(d => d.PlaySession).WithMany(p => p.PlaySessionParticipants)
                .HasForeignKey(d => d.PlaySessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_psp_session");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__publishe__3213E83FFEE4E2E5");

            entity.ToTable("publishers");

            entity.HasIndex(e => e.Name, "UX_publisher_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PublicId)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("public_id");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => new { e.MemberId, e.BoardGameId }).HasName("PK__ratings__496280B181672985");

            entity.ToTable("ratings");

            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.BoardGameId).HasColumnName("board_game_id");
            entity.Property(e => e.RatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("rated_at");
            entity.Property(e => e.Rating1)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("rating");
            entity.Property(e => e.Review)
                .HasMaxLength(1000)
                .HasColumnName("review");

            entity.HasOne(d => d.BoardGame).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.BoardGameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ratings__board_g__6477ECF3");

            entity.HasOne(d => d.Member).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ratings__member___6383C8BA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
