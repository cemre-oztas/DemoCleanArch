using CleanArch.Domain.Entities.Identity;
using CleanArch.Domain.Entities; // Basket, Product gibi varlıklar için
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // IdentityDbContext için
using Microsoft.EntityFrameworkCore;
using CleanArch.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CleanArch.Persistence.Contexts
{
    public class APIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        { }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<BasketEntity> Baskets { get; set; }
        public DbSet<BasketItemEntity> BasketItems { get; set; }
        public DbSet<CompletedOrderEntity> CompletedOrders { get; set; }
        public DbSet<MenuEntity> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderEntity>()
                .HasKey(b => b.Id);

            builder.Entity<OrderEntity>()
                .HasIndex(o => o.OrderCode)
                .IsUnique();

            builder.Entity<BasketEntity>()
                .HasOne(b => b.Order)
                .WithOne(o => o.Basket)
                .HasForeignKey<OrderEntity>(b => b.Id);

            builder.Entity<OrderEntity>()
                .HasOne(o => o.CompletedOrder)
                .WithOne(c => c.Order)
                .HasForeignKey<CompletedOrderEntity>(c => c.OrderId);

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                }
                ;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
