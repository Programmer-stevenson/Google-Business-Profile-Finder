using Microsoft.EntityFrameworkCore;
using LeadHunterUI.Models;

namespace LeadHunterUI.Data;

public class LeadDbContext : DbContext
{
    public DbSet<BusinessLead> Leads => Set<BusinessLead>();
    public DbSet<SearchHistory> SearchHistory => Set<SearchHistory>();

    public LeadDbContext(DbContextOptions<LeadDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusinessLead>(entity =>
        {
            entity.HasIndex(e => e.PlaceId).IsUnique();
            entity.HasIndex(e => new { e.Industry, e.City });
        });
    }
}
