﻿using System;
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
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BatchSupplier> BatchSuppliers { get; set; }
        public DbSet<Batch> Batches { get; set; }
    }
}