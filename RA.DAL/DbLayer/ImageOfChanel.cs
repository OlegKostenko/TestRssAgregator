using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DAL.DbLayer
{
    [Table("ImageOfChanel")]
    public class ImageOfChanel
    {
        [Key]
        public int ImgId { get; set; }

        [StringLength(50)]
        public string ImgTitle { get; set; }

        [StringLength(150)]
        public string ImgLink { get; set; }

        [StringLength(150)]
        public string ImgUrl { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
