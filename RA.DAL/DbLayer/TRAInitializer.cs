using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DAL.DbLayer
{
    public class TRAInitializer : DropCreateDatabaseIfModelChanges<TRAContext>
    {
        protected override void Seed(TRAContext context)
        {
            var RssRepositories = new List<RssRepository>()
            {
                new RssRepository() { Id = 1, Description = "Some test content", CopyRight = "test CR", Link = "test URL", Title = "test Title", Item = new Item() {
                     ItemId = 1,
                     Title = "Some test Item title",
                     Description = "some test rss Item",
                     UpdateOn = DateTime.Now,
                     Link = "https://www.w3schools.com/xml/xml_rss.asp"
                } }
            };

            RssRepositories.ForEach(s => context.RssRepositories.Add(s));
            context.SaveChanges();
        }
    }
}
