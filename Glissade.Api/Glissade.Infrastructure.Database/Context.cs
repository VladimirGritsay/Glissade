using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glissade.Infrastructure.Database {
    public class Context : DbContext {
        public Context() : base("Context") {
        }
        public DbSet<ScreenDAO> Screens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<ScreenDAO>().ToTable("Screens");
            base.OnModelCreating(modelBuilder);
        }
    }
}
