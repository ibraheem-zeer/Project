using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<Users, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure the IdentityUserLogin<int> primary key
            builder.Entity<IdentityUserLogin<int>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });

            // Configure the IdentityUserRole<int> primary key
            builder.Entity<IdentityUserRole<int>>().HasKey(x => new { x.UserId, x.RoleId });

            // Configure the IdentityUserToken<int> primary key
            builder.Entity<IdentityUserToken<int>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

            builder.Entity<Users>().ToTable("AspNetUsers");
            builder.Entity<ItemsStores>().HasKey(i => new { i.StoreId, i.ItemId });
            builder.Entity<ItemsUnits>().HasKey(i => new { i.UnitId, i.ItemId });
            builder.Entity<CustomerStores>().HasKey(c => new { c.CustomerId, c.StoreId });
            builder.Entity<ShoppingCartItems>().HasKey(sc => new { sc.StoreId, sc.CusId, sc.ItemId });
            builder.Entity<Zones>().HasOne(g => g.Govermments).WithMany(z => z.Zones).HasForeignKey(g => g.GovermmentsId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SubGroup2>()
            .HasOne(sg2 => sg2.SubGroup)
            .WithMany(sg => sg.SubGroups2)
            .HasForeignKey(sg2 => sg2.SubGroupId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Users>()
            .HasOne(u => u.Govermments) // The navigation property in Users
            .WithMany(g => g.Users)     // The navigation property in Govermments
            .HasForeignKey(u => u.GovermmentsId)
            .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<InvoiceDetails>
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Govermments> Governments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetail { get; set; }
        public DbSet<ItemsStores> ItemsStores { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<ItemsUnits> ItemsUnits { get; set; }
        public DbSet<CustomerStores> CustomerStores { get; set; }
        public DbSet<IdentityRole<int>> Roles { get; set; }
        public DbSet<Classifications> Classifications { get; set; }
        public DbSet<ShoppingCartItems> ShoppingCartItem { get; set; }
        public DbSet<MainGroup> MainGroup { get; set; }
        public DbSet<SubGroup> SubGroup { get; set; }
        public DbSet<SubGroup2> SubGroup2 { get; set; }
    }
}
