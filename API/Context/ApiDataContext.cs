using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Context {

	public partial class ApiDataContext : DbContext {
		public ApiDataContext() { }

		public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			if (!optionsBuilder.IsConfigured) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlServer("Server=localhost;Database=PigFarmDB;Trusted_Connection=True;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) { }

		public DbSet<Box> BoxTable { get; set; }
		public DbSet<TemperatureSensor> TemperatureTable { get; set; }
	}

}