using Microsoft.EntityFrameworkCore;
using InventoryWebApi.Models;

namespace InventoryWebApi.Models
{
    public class InventoryDBContext : DbContext
    {
        public InventoryDBContext()
        {
        }

        public InventoryDBContext(DbContextOptions<InventoryDBContext> options) : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public object Category { get; internal set; }
        public object Role { get; internal set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-O1MC9QD\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True;TrustServerCertificate=True");
        public DbSet<InventoryWebApi.Models.Role> Role_1 { get; set; } = default!;


    }

}
