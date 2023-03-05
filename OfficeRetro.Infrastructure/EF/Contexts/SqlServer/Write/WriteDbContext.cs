using Microsoft.EntityFrameworkCore;
using OfficeRetro.Domain.Inquiry.Entities;
using OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Write.Configs.Inquiry;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Write;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<Inquiry> Inquiries { get; set; }
    public DbSet<InquiryFile> InquiryFiles { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("OfficeRetro");

        ApplyConfiguration(modelBuilder);
    }

    private void ApplyConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InquiryWriteConfig());
        modelBuilder.ApplyConfiguration(new InquiryFileWriteConfig());
    }
}
