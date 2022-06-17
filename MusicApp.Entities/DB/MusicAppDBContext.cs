using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MusicApp.Entities.Models;

#nullable disable

namespace MusicApp.Entities.DB
{
    public partial class MusicAppDBContext : IdentityDbContext<ApplicationUser>
    {
        public MusicAppDBContext(DbContextOptions<MusicAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtistsUser> ArtistsUsers { get; set; }
        public virtual DbSet<Coutry> Coutries { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongPlayedLog> SongPlayedLogs { get; set; }
        public virtual DbSet<SongsUser> SongsUsers { get; set; }

        //       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //    modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //    modelBuilder.Entity<Album>(entity =>
            //    {


            //        entity.Property(e => e.AlbumName).IsRequired();
            //        entity.Property(e => e.Id).ValueGeneratedOnAdd();

            //        entity.HasOne(d => d.Artist)
            //            .WithMany(p => p.Albums)
            //            .HasForeignKey(d => d.ArtistId);
            //    });

            //    modelBuilder.Entity<Artist>(entity =>
            //    {
            //        entity.HasIndex(e => e.CoutryId, "IX_Artists_CoutryId");

            //        entity.Property(e => e.Id).ValueGeneratedOnAdd();

            //        entity.HasOne(d => d.Coutry)
            //            .WithMany(p => p.Artists)
            //            .HasForeignKey(d => d.CoutryId);
            //    });


            //    modelBuilder.Entity<ArtistsUser>(entity =>
            //    {
            //        entity.ToTable("Artists_Users");

            //        entity.HasIndex(e => e.ArtistId, "IX_Artists_Users_ArtistId");

            //        entity.HasIndex(e => e.UserId, "IX_Artists_Users_UserId");

            //        entity.HasOne(d => d.Artist)
            //            .WithMany(p => p.ArtistsUsers)
            //            .HasForeignKey(d => d.ArtistId);

            //        entity.HasOne(d => d.ApplicationUser)
            //            .WithMany(p => p.ArtistsUsers)
            //            .HasForeignKey(d => d.UserId);
            //    });

            //    modelBuilder.Entity<ArtistsUser>(entity =>
            //    {
            //        entity.ToTable("Artists_Users");

            //        entity.HasIndex(e => e.ArtistId, "IX_Artists_Users_ArtistId");

            //        entity.HasIndex(e => e.UserId, "IX_Artists_Users_UserId");

            //        entity.HasOne(d => d.Artist)
            //            .WithMany(p => p.ArtistsUsers)
            //            .HasForeignKey(d => d.ArtistId);

            //        entity.HasOne(d => d.ApplicationUser)
            //            .WithMany(p => p.ArtistsUsers)
            //            .HasForeignKey(d => d.UserId);
            //    });

            //    modelBuilder.Entity<Coutry>(entity =>
            //    {
            //        entity.Property(e => e.Id).ValueGeneratedNever();
            //    });

            //    modelBuilder.Entity<Publisher>(entity =>
            //    {
            //        entity.Property(e => e.Id).ValueGeneratedNever();
            //    });

            //    modelBuilder.Entity<Song>(entity =>
            //    {
            //        entity.HasIndex(e => e.AlbumId, "IX_Songs_AlbumId");

            //        entity.HasIndex(e => e.ArtistId, "IX_Songs_ArtistId");

            //        entity.HasIndex(e => e.GenreId, "IX_Songs_GenreId");

            //        entity.HasIndex(e => e.PublisherId, "IX_Songs_PublisherId");


            //        entity.Property(e => e.Id).ValueGeneratedOnAdd();

            //        entity.HasOne(d => d.Album)
            //            .WithMany(p => p.Songs)
            //            .HasForeignKey(d => d.AlbumId);

            //        entity.HasOne(d => d.Artist)
            //            .WithMany(p => p.Songs)
            //            .HasForeignKey(d => d.ArtistId);

            //        entity.HasOne(d => d.Genre)
            //            .WithMany(p => p.Songs)
            //            .HasForeignKey(d => d.GenreId);

            //        entity.HasOne(d => d.Publisher)
            //            .WithMany(p => p.Songs)
            //            .HasForeignKey(d => d.PublisherId);
            //    });

            //    modelBuilder.Entity<SongPlayedLog>(entity =>
            //    {
            //        entity.HasIndex(e => e.UserId, "IX_SongPlayedLogs_UserId");

            //        entity.HasOne(d => d.ApplicationUser)
            //            .WithMany(p => p.UserListeningHistory)
            //            .HasForeignKey(d => d.UserId);

            //    });

            //    modelBuilder.Entity<SongsUser>(entity =>
            //    {
            //        entity.ToTable("Songs_Users");


            //        entity.HasIndex(e => e.SongId, "IX_Songs_Users_SongId");

            //        entity.HasIndex(e => e.UserId, "IX_Songs_Users_UserId");

            //        entity.HasOne(d => d.Song)
            //            .WithMany(p => p.SongsUsers)
            //            .HasForeignKey(d => d.SongId);

            //        entity.HasOne(d => d.ApplicationUser)
            //            .WithMany(p => p.SongsUsers)
            //            .HasForeignKey(d => d.UserId);
            //    });

            //    //modelBuilder.Entity<ApplicationUser>(entity =>
            //    //{
            //    //    entity.HasKey(e => e.Id);
            //    //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //    //});

            //OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    Email = "Ohad@gmail.com",
                    FirstName = "Ohad",
                    LastName = "Saadia",
                    PasswordHash = "11111111",
                }
                );

            modelBuilder.Entity<Coutry>().HasData(
                   new Coutry
                   {
                       Id = 1,
                       Name = "Israel"
                   },
                   new Coutry
                   {
                       Id = 2,
                       Name = "Use"
                   },
                   new Coutry
                   {
                       Id = 3,
                       Name = "Spain"
                   },
                   new Coutry
                   {
                       Id = 4,
                       Name = "Japan"
                   }

                   );


            modelBuilder.Entity<Artist>().HasData(
               new Artist
               {
                   Id = 1,
                   StageName = "Infected Mushroom",
                   FirstName = "Erez",
                   LastName = "Duvdev",
                   CoutryId = 1

               },
               new Artist
               {
                   Id = 2,
                   StageName = "New Born",
                   FirstName = "Yuval",
                   LastName = "Terner",
                   CoutryId = 1

               },
               new Artist
               {
                   Id = 3,
                   StageName = "Ice Cube",
                   FirstName = "Mok",
                   LastName = "Row",
                   CoutryId = 2

               },
               new Artist
               {
                   Id = 4,
                   StageName = "Samorai",
                   FirstName = "Kun",
                   LastName = "Jang",
                   CoutryId = 4

               },
               new Artist
               {
                   Id = 5,
                   StageName = "Enrike",
                   FirstName = "Enrike",
                   LastName = "du",
                   CoutryId = 3

               }
               );
            modelBuilder.Entity<Genre>().HasData(
               new Genre
               {
                   Id = 1,
                   Name = "Pop"
               },
               new Genre
               {
                   Id = 2,
                   Name = "Trance"
               },
               new Genre
               {
                   Id = 3,
                   Name = "Rock"
               });
            modelBuilder.Entity<Publisher>().HasData(
            new Publisher
            {
                Id = 1,
                CompanyName = "Nano Records",
                DayOfFounding = new DateTime(1990, 08, 08)
            },
            new Publisher
            {
                Id = 2,
                CompanyName = "ACD",
                DayOfFounding = new DateTime(1977, 07, 28)
            },
            new Publisher
            {
                Id = 3,
                CompanyName = "RRE",
                DayOfFounding = new DateTime(1955, 12, 08)
            }
            );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
