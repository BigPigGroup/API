using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context {

	public partial class ApiDataContext : DbContext {
		public ApiDataContext() { }

		public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			if (!optionsBuilder.IsConfigured) {
				optionsBuilder.UseSqlServer("Server=192.168.1.3;Database=PigFarmDB;Integrated Security=False;User ID=sa;Password=Pa$$w0rd;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Box>().HasKey(c => new {BoxID = c.BoxNo});
			modelBuilder.Entity<TemperatureSensor>().HasKey(c => new {c.BoxNo, c.CtsNo});

			//Set Foreign key on 
			modelBuilder.Entity<Box>()
				.HasOne(a => a.TemperatureSensor)
				.WithOne(b => b.Box)
				.HasForeignKey<TemperatureSensor>(b => b.BoxNo);
			//Add index but allow duplicate values by setting IsUnique(false)
			modelBuilder.Entity<TemperatureSensor>().HasIndex(u => u.BoxNo).IsUnique(false);
		}

		public DbSet<Box> Box { get; set; }

		public DbSet<TemperatureSensor> Temperature { get; set; }
	}

}