using Microsoft.EntityFrameworkCore;
using OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read.Configs.Auth;
using OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read.Configs.Inquiry;
using OfficeRetro.Infrastructure.EF.Domains.Auth.Models;
using OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<UserReadModel> Users { get; set; }
    public DbSet<UserRefreshTokenReadModel> UserRefreshTokens { get; set; }
    public DbSet<UserActivationReadModel> UserActivations { get; set; }
    public DbSet<UserPasswordResetReadModel> UserPasswordResets { get; set; }
    public DbSet<InquiryReadModel> Inquiries { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("OfficeRetro");

        ApplyConfiguration(modelBuilder);
    }

    private void ApplyConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserReadConfig());
        modelBuilder.ApplyConfiguration(new UserRefreshTokenReadConfig());
        modelBuilder.ApplyConfiguration(new UserActivationReadConfig());
        modelBuilder.ApplyConfiguration(new UserPasswordResetReadConfig());
        modelBuilder.ApplyConfiguration(new InquiryReadConfig());
        modelBuilder.ApplyConfiguration(new InquiryFileReadConfig());
        modelBuilder.ApplyConfiguration(new InquiryAnswerReadConfig());
        modelBuilder.ApplyConfiguration(new InquiryAnswerFileReadConfig());
    }
}
