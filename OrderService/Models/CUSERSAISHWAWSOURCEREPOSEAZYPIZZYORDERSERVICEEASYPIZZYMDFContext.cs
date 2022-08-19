using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OrderService.Models
{
    public partial class CUSERSAISHWAWSOURCEREPOSEAZYPIZZYORDERSERVICEEASYPIZZYMDFContext : DbContext
    {
        public CUSERSAISHWAWSOURCEREPOSEAZYPIZZYORDERSERVICEEASYPIZZYMDFContext()
        {
        }

        public CUSERSAISHWAWSOURCEREPOSEAZYPIZZYORDERSERVICEEASYPIZZYMDFContext(DbContextOptions<CUSERSAISHWAWSOURCEREPOSEAZYPIZZYORDERSERVICEEASYPIZZYMDFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Outlet> Outlets { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<ToppingType> ToppingTypes { get; set; }
        public virtual DbSet<ToppingsInvetoryList> ToppingsInvetoryLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\AISHWAW\\source\\repos\\EazyPizzy\\OrderService\\EasyPizzy.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Outlet>(entity =>
            {
                entity.ToTable("Outlet");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OutletAddress)
                    .HasMaxLength(80)
                    .IsFixedLength(true);

                entity.Property(e => e.OutletName)
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza");

                entity.Property(e => e.ToppingList)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ToppingType>(entity =>
            {
                entity.ToTable("ToppingType");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ToppingTypeDescripion)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.ToppingTypeName)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ToppingsInvetoryList>(entity =>
            {
                entity.ToTable("ToppingsInvetoryList");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ToppingCost).HasColumnType("money");

                entity.Property(e => e.ToppingDescription)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.ToppingName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ToppingType)
                    .WithMany(p => p.ToppingsInvetoryLists)
                    .HasForeignKey(d => d.ToppingTypeId)
                    .HasConstraintName("FK_ToppingsInventoryList_ToppingType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
