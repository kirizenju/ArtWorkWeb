using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ImageList> ImageLists { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<PreOrder> PreOrders { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=ArtWorkDB;User Id=sa;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artwork>(entity =>
            {
                entity.HasKey(e => e.IdArtwork)
                    .HasName("PK__Artwork__B99D1B3D364C5FFA");

                entity.ToTable("Artwork");

                entity.Property(e => e.IdArtwork).HasColumnName("Id_Artwork");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Artwork__Categor__3F466844");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK__Artwork__Owner__3E52440B");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__ECCA5BBDE92D1838");

                entity.ToTable("Category");

                entity.Property(e => e.IdCategory).HasColumnName("Id_Category");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<ImageList>(entity =>
            {
                entity.HasKey(e => e.IdImageList)
                    .HasName("PK__ImageLis__4B65C80E596B3561");

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
                    .HasConstraintName("FK__ImageList__Artwo__4222D4EF");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => e.IdLike)
                    .HasName("PK__Like__0CCAFD6AFC42C1C1");

                entity.ToTable("Like");

                entity.Property(e => e.IdLike).HasColumnName("Id_Like");

                entity.Property(e => e.ArtworkId).HasColumnName("Artwork_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.ArtworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Like__Artwork_Id__45F365D3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Like__User_Id__44FF419A");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Order__370733B205CBA7C7");

                entity.ToTable("Order");

                entity.Property(e => e.IdOrder).HasColumnName("Id_Order");

                entity.Property(e => e.ArtworkId).HasColumnName("Artwork_Id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ArtworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__Artwork_I__49C3F6B7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__User_Id__48CFD27E");
            });

            modelBuilder.Entity<PreOrder>(entity =>
            {
                entity.HasKey(e => e.IdPreOrder)
                    .HasName("PK__PreOrder__23EB4B3EE4B4ACC3");

                entity.ToTable("PreOrder");

                entity.Property(e => e.IdPreOrder).HasColumnName("Id_PreOrder");

                entity.Property(e => e.ArtworkId).HasColumnName("Artwork_Id");

                entity.Property(e => e.Desc).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.PreOrders)
                    .HasForeignKey(d => d.ArtworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PreOrder__Artwor__534D60F1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PreOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PreOrder__User_I__52593CB8");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.IdSubscription)
                    .HasName("PK__Subscrip__0E61A92FDC1E3726");

                entity.ToTable("Subscription");

                entity.Property(e => e.IdSubscription).HasColumnName("Id_Subscription");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.IdPayment)
                    .HasName("PK__Transact__17C40C663B438290");

                entity.ToTable("Transaction");

                entity.Property(e => e.IdPayment).HasColumnName("Id_Payment");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.SubscriptionId).HasColumnName("Subscription_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Subsc__4F7CD00D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__User___4E88ABD4");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__D03DEDCB726A7E49");

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
