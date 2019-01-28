using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DAL.DbLayer
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? UpdateOn { get; set; }

        public int ImgId { get; set; }

        public virtual ImageOfChanel ImageOfChanel { get; set; }

        public virtual ICollection<RssRepository> RssRepositories { get; set; }
    }
}
