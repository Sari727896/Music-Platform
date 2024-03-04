using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Do;

public partial class MusicContext : DbContext
{
    public MusicContext(DbContextOptions<MusicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Composer> Composers { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Processor> Processors { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Singer> Singers { get; set; }

    public virtual DbSet<SingerSong> SingerSongs { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    public virtual DbSet<SubscriberSong> SubscriberSongs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Album__A25C5AA63E93D7F7");

            entity.ToTable("Album");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.PublicationDate).HasColumnType("date");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC07B0FB82E2");

            entity.ToTable("City");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CityCountry");
        });

        modelBuilder.Entity<Composer>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Composer__A25C5AA66F785209");

            entity.ToTable("Composer");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Id)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("ID");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.City).WithMany(p => p.Composers)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComposerCity");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC0799A4137C");

            entity.ToTable("Country");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Processor>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Processo__A25C5AA606BEF283");

            entity.ToTable("Processor");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Id)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("ID");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.City).WithMany(p => p.Processors)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProcessorCity");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rating__3214EC070C851695");

            entity.ToTable("Rating");

            entity.HasOne(d => d.Song).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RatingSong");
        });

        modelBuilder.Entity<Singer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Singer__A25C5AA6D87DBC5D");

            entity.ToTable("Singer");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.City).WithMany(p => p.Singers)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_SingerCity");
        });

        modelBuilder.Entity<SingerSong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SingerSo__3214EC07F8625800");

            entity.HasOne(d => d.Singer).WithMany(p => p.SingerSongs)
                .HasForeignKey(d => d.SingerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SingerSongs_Singer");

            entity.HasOne(d => d.Song).WithMany(p => p.SingerSongs)
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SingerSongs_Song");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Song__3214EC07603D6E56");

            entity.ToTable("Song");

            entity.Property(e => e.ComposerName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ProcessorName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.PublicationDate).HasColumnType("date");
            entity.Property(e => e.TheSongWriter)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Album).WithMany(p => p.Songs)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK_SongAlbum");
        });

        modelBuilder.Entity<Subscriber>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Subscrib__A25C5AA6B2FEA2F4");

            entity.ToTable("Subscriber");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Id)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("ID");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<SubscriberSong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrib__3214EC07A52465CA");

            entity.HasOne(d => d.Song).WithMany(p => p.SubscriberSongs)
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriberSongs_Song");

            entity.HasOne(d => d.Subscriber).WithMany(p => p.SubscriberSongs)
                .HasForeignKey(d => d.SubscriberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriberSongs_Subscriber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
