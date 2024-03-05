using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataTier.Models
{
    public partial class ArtWorkDBContext : DbContext
    {
        public ArtWorkDBContext()
        {
        }

        public ArtWorkDBContext(DbContextOptions<ArtWorkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artwork> Artworks { get; set; } = null!;
        public virtual DbSet<ImageList> ImageLists { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<PreOrder> PreOrders { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                  .SetBasePath(Directory.GetCurrentDirectory())
                                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQLServerDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artwork>(entity =>
            {
                entity.HasKey(e => e.IdArtwork)
                    .HasName("PK__Artwork__B99D1B3D6125EB76");

                entity.ToTable("Artwork");

                entity.Property(e => e.IdArtwork).HasColumnName("Id_Artwork");

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK__Artwork__Owner__44FF419A");
            });

            modelBuilder.Entity<ImageList>(entity =>
            {
                entity.HasKey(e => e.IdImageList)
                    .HasName("PK__ImageLis__4B65C80E1906D5A3");

                entity.ToTable("ImageList");

                entity.Property(e => e.IdImageList).HasColumnName("Id_ImageList");

                entity.Property(e => e.ArtworkId).HasColumnName("Artwork_Id");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ImageURL");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.ImageLists)
                    .HasForeignKey(d => d.ArtworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImageList__Artwo__45F365D3");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => e.IdLike)
                    .HasName("PK__Like__0CCAFD6ADA25348A");

                entity.ToTable("Like");

                entity.Property(e => e.IdLike).HasColumnName("Id_Like");

                entity.Property(e => e.ArtworkId).HasColumnName("Artwork_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.ArtworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Like__Artwork_Id__46E78A0C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Like__User_Id__47DBAE45");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Order__370733B25CC3ECCF");

                entity.ToTable("Order");

                entity.Property(e => e.IdOrder).HasColumnName("Id_Order");

                entity.Property(e => e.ArtworkId).HasColumnName("Artwork_Id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ArtworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__Artwork_I__48CFD27E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__User_Id__49C3F6B7");
            });

            modelBuilder.Entity<PreOrder>(entity =>
            {
                entity.HasKey(e => e.IdPreOrder)
                    .HasName("PK__PreOrder__23EB4B3EA98389CB");

                entity.ToTable("PreOrder");

                entity.Property(e => e.IdPreOrder).HasColumnName("Id_PreOrder");

                entity.Property(e => e.ArtworkId).HasColumnName("Artwork_Id");

                entity.Property(e => e.DescPreOrder).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.PreOrders)
                    .HasForeignKey(d => d.ArtworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PreOrder__Artwor__4AB81AF0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PreOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PreOrder__User_I__4BAC3F29");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.IdSubscription)
                    .HasName("PK__Subscrip__0E61A92F185C6EC3");

                entity.ToTable("Subscription");

                entity.Property(e => e.IdSubscription).HasColumnName("Id_Subscription");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SubscriptionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.IdPayment)
                    .HasName("PK__Transact__17C40C66679051A3");

                entity.ToTable("Transaction");

                entity.Property(e => e.IdPayment).HasColumnName("Id_Payment");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.SubscriptionId).HasColumnName("Subscription_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Subsc__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__User___4D94879B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__D03DEDCB56F397B4");

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
