using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using FishFarm.Models;

namespace FishFarm.Data
{
    public class FishFarmDataContext : DbContext
    {
        public FishFarmDataContext(DbContextOptions<FishFarmDataContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Tank>().Property(nameof(Tank.Status)).HasDefaultValue(true);
            modelBuilder.Entity<Supplier>().Property(nameof(Supplier.Status)).HasDefaultValue(true);
            modelBuilder.Entity<Section>().Property(nameof(Section.Status)).HasDefaultValue(true);
            modelBuilder.Entity<Out>().Property(nameof(Out.Status)).HasDefaultValue(true);
            modelBuilder.Entity<MesurmentUnit>().Property(nameof(MesurmentUnit.Status)).HasDefaultValue(true);
            modelBuilder.Entity<InventoryItem>().Property(nameof(InventoryItem.Status)).HasDefaultValue(true);
            modelBuilder.Entity<InventoryIn>().Property(nameof(InventoryIn.Status)).HasDefaultValue(true);
            modelBuilder.Entity<In>().Property(nameof(In.Status)).HasDefaultValue(true);
            modelBuilder.Entity<InOut>().Property(nameof(InOut.Status)).HasDefaultValue(true);
            modelBuilder.Entity<DailyReport>().Property(nameof(DailyReport.Status)).HasDefaultValue(true);
            modelBuilder.Entity<Contact>().Property(nameof(Contact.Status)).HasDefaultValue(true);
            modelBuilder.Entity<Batch>().Property(nameof(Batch.Status)).HasDefaultValue(true);

        }

        public DbSet<Section> Sections { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Contact> SupplierContacts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Out> Outs { get; set; }
        public DbSet<MesurmentUnit> MesurmentUnits { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryIn> InventoryIns { get; set; }
        public DbSet<InOut> InOuts { get; set; }
        public DbSet<In> Ins { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Batch> Batches { get; set; }
    }
}
