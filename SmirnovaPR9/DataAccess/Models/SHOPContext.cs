using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class SHOPContext : DbContext
    { 
        public SHOPContext()
        {

        }
        public SHOPContext(DbContextOptions<SHOPContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server = DESKTOP-DP4OCKO; Database = SHOP; Integrated Security = true;");
            }

        }
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; } = null!;
        public virtual DbSet<Filter> Filters { get; set; } = null!;
        public virtual DbSet<PriceChange> PriceChanges { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.ProductId })
                    .HasName("PK_PURCHASE_ITEMS");

                entity.ToTable("Cart_items");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ProductCount).HasColumnName("product_count");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("numeric(9, 2)")
                    .HasColumnName("product_price");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_item__cart___47DBAE45");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_item__produ__46E78A0C");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .HasColumnName("category_name");

                entity.Property(e => e.FilterId).HasColumnName("filter_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.HasOne(d => d.Filter)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.FilterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Categorie__filte__398D8EEE");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(100)
                    .HasColumnName("customer_email");

                entity.Property(e => e.CustomerFname)
                    .HasMaxLength(100)
                    .HasColumnName("customer_fname");

                entity.Property(e => e.CustomerLname)
                    .HasMaxLength(100)
                    .HasColumnName("customer_lname");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("date")
                    .HasColumnName("delivery_date");

                entity.Property(e => e.DeliveryMethodId).HasColumnName("delivery_method_id");

                entity.Property(e => e.DeliveryStatus)
                    .HasMaxLength(50)
                    .HasColumnName("delivery_status");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.HasOne(d => d.Cart)
                    .WithMany()
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deliverie__cart___4BAC3F29");

                entity.HasOne(d => d.DeliveryMethod)
                    .WithMany()
                    .HasForeignKey(d => d.DeliveryMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deliverie__deliv__4CA06362");
            });

            modelBuilder.Entity<DeliveryMethod>(entity =>
            {
                entity.ToTable("Delivery_method");

                entity.Property(e => e.DeliveryMethodId).HasColumnName("delivery_method_id");

                entity.Property(e => e.DeliveryMethodName)
                    .HasMaxLength(100)
                    .HasColumnName("delivery_method_name");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            });

            modelBuilder.Entity<Filter>(entity =>
            {
                entity.Property(e => e.FilterId).HasColumnName("filter_id");

                entity.Property(e => e.FilterName)
                    .HasMaxLength(100)
                    .HasColumnName("filter_name");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            });

            modelBuilder.Entity<PriceChange>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.DatePriceChange })
                    .HasName("PK_PRICE_CHANGE");

                entity.ToTable("Price_change");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.DatePriceChange)
                    .HasColumnType("date")
                    .HasColumnName("date_price_change");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.NewPrice)
                    .HasColumnType("numeric(9, 2)")
                    .HasColumnName("new_price");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PriceChanges)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Price_cha__produ__3F466844");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ProductCount).HasColumnName("product_count");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .HasColumnName("product_name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__catego__3C69FB99");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Shopping__2EF52A27A2F44812");

                entity.ToTable("Shopping_cart");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cart_date");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shopping___custo__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
