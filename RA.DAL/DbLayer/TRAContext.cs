using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DAL.DbLayer
{
    public class TRAContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<RssRepository> RssRepositories { get; set; }
        public DbSet<ImageOfChanel> ImageOfChanels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageOfChanel>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.ImageOfChanel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.RssRepositories)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);
        }

        static TRAContext()
        {
            Database.SetInitializer<TRAContext>(new TRAInitializer());
        }

        public TRAContext() : base("name=TRAContext") { }
    }
}
