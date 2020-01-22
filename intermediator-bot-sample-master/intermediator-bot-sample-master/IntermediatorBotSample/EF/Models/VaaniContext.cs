using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IntermediatorBotSample.EF.Models
{
    public partial class VaaniContext : DbContext
    {
        public VaaniContext()
        {
        }

        public VaaniContext(DbContextOptions<VaaniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BotPlans> BotPlans { get; set; }
        public virtual DbSet<EndCustomer> EndCustomer { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<RoleMenu> RoleMenu { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SecurityQuestions> SecurityQuestions { get; set; }
        public virtual DbSet<UserSecurityQuestions> UserSecurityQuestions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8J1I408;Database=Vaani;User Id=sa;Password=sap;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<BotPlans>(entity =>
            {
                entity.Property(e => e.IsActive).HasMaxLength(10);
            });

            modelBuilder.Entity<EndCustomer>(entity =>
            {
                entity.Property(e => e.EmailId).HasMaxLength(128);

                entity.Property(e => e.EndCustomerGuid).HasColumnName("EndCustomerGUID");

                entity.Property(e => e.PhoneNumber).HasMaxLength(24);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.EndCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_EndCustomer_Users");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.MenuName).HasMaxLength(24);
            });

            modelBuilder.Entity<RoleMenu>(entity =>
            {
                entity.ToTable("Role_Menu");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.RoleMenu)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Menu_Menu");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMenu)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Menu_Roles");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Role).HasMaxLength(24);
            });

            modelBuilder.Entity<UserSecurityQuestions>(entity =>
            {
                entity.ToTable("User_SecurityQuestions");
            });

            modelBuilder.Entity<Users>(entity =>
            {
               
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FirstName).HasMaxLength(24);

                entity.Property(e => e.LastName).HasMaxLength(24);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.PhoneNumbers).HasMaxLength(24);

                entity.Property(e => e.RegisteredOn).HasColumnType("date");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });
        }
    }
}
