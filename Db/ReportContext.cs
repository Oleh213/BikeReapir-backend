using System;
using BikeRepair_backend.Context;
using Microsoft.EntityFrameworkCore;

namespace BikeRepair_backend.Db
{
	public class ReportContext : DbContext
    {
        public DbSet<BikeReport> BikeReports { get; set; }

        public string DbPath { get; }

        public ReportContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "database.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}

