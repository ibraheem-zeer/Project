using Microsoft.EntityFrameworkCore;
using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
//            base.OnModelCreating(builder);

//            // Configure Many-to-Many relationship for Items and Stores
//            builder.Entity<ItemsStores>()
//                .HasKey(x => new { x.StoreId, x.ItemId });

//            builder.Entity<ItemsStores>()
//                .HasOne(x => x.Stores)
//                .WithMany(x => x.ItemsStores)
//                .HasForeignKey(x => x.StoreId);

//            builder.Entity<ItemsStores>()
//                .HasOne(x => x.Items)
//                .WithMany(x => x.ItemsStores)
//                .HasForeignKey(x => x.ItemId);

//            // Configure One-to-Many relationships
//            builder.Entity<Users>()
//                .HasOne(u => u.Governments)
//                .WithMany(g => g.Users)
//                .HasForeignKey(u => u.Government_Code);

//            builder.Entity<Users>()
//                .HasOne(u => u.Cities)
//                .WithMany(c => c.Users)
//                .HasForeignKey(u => u.City_Code);

//            builder.Entity<Users>()
//                .HasOne(u => u.Zones)
//                .WithMany(z => z.Users)
//                .HasForeignKey(u => u.Zone_Code);

//            builder.Entity<Users>()
//                .HasOne(u => u.Classifications)
//                .WithMany(c => c.Users)
//                .HasForeignKey(u => u.Cus_ClassId);

//            // Configure relationships for MainGroup, SubGroup, and SubGroup2
//            builder.Entity<MainGroup>()
//                .HasMany(m => m.SubGroup)
//                .WithOne(s => s.MainGroup)
//                .HasForeignKey(s => s.MG_Id);

//            builder.Entity<SubGroup>()
//                .HasMany(s => s.SubGroup2)
//                .WithOne(s2 => s2.SubGroup)
//                .HasForeignKey(s2 => s2.SG_Id);

//            // Configure relationships for Items and Units
//            builder.Entity<ItemsUnits>()
//                .HasKey(iu => new { iu.ItemCode, iu.UnitCode });

//            builder.Entity<ItemsUnits>()
//                .HasOne(iu => iu.Items)
//                .WithMany(i => i.ItemsUnits)
//                .HasForeignKey(iu => iu.ItemCode);

//            builder.Entity<ItemsUnits>()
//                .HasOne(iu => iu.Units)
//                .WithMany(u => u.ItemsUnits)
//                .HasForeignKey(iu => iu.UnitCode);

//            // Configure relationships for InvoiceDetails and Invoices
//            builder.Entity<InvoiceDetail>()
//                .HasOne(id => id.Invoices)
//                .WithMany(i => i.InvoiceDetail)
//                .HasForeignKey(id => id.InvoiceId);

//            builder.Entity<InvoiceDetail>()
//                .HasOne(id => id.Items)
//                .WithMany(i => i.InvoiceDetail)
//                .HasForeignKey(id => id.ItemCode);

//            // Configure relationships for ShoppingCartItems
//            builder.Entity<ShoppingCartItem>()
//                .HasOne(sci => sci.Items)
//                .WithMany(i => i.ShoppingCartItem)
//                .HasForeignKey(sci => sci.ItemCode);

//            builder.Entity<ShoppingCartItem>()
//                .HasOne(sci => sci.Users)
//                .WithMany(u => u.ShoppingCartItem)
//                .HasForeignKey(sci => sci.U_Code);

//            // Configure relationships for CustomerStores
//            builder.Entity<CustomerStores>()
//                .HasKey(cs => new { cs.Cus_Id, cs.StoreId });

///*            builder.Entity<CustomerStores>()
//                .HasOne(cs => cs.Users)
//                .WithMany(u => u)
//                .HasForeignKey(cs => cs.UserId);*/

//            //builder.Entity<CustomerStores>()
//            //    .HasOne(cs => cs.Stores)
//            //    .WithMany(s => s.CustomerStores)
//            //    .HasForeignKey(cs => cs.StoreId);
        }

        // DbSet properties for all entities
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Zones> Zones { get; set; }
        public DbSet<Governments> Governments { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Classifications> Classifications { get; set; }
        public DbSet<ItemsStores> ItemsStores { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ItemsUnits> ItemsUnits { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<MainGroup> MainGroups { get; set; }
        public DbSet<SubGroup> SubGroups { get; set; }
        public DbSet<SubGroup2> SubGroup2s { get; set; }
        public DbSet<CustomerStores> CustomerStores { get; set; }
    }
}
