using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KupujemProdajemClone.DataLayer;

public class KupujemProdajemCloneContext : DbContext
{
    public KupujemProdajemCloneContext(DbContextOptions<KupujemProdajemCloneContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}