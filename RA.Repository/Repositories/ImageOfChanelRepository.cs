using RA.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace RA.Repository.Repositories
{
    public class ImageOfChanelRepository : GenericRepository<ImageOfChanel>
    {
        public ImageOfChanelRepository(DbContext context) : base(context) { }
    }
}
