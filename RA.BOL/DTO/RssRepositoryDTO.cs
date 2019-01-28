using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.BOL.DTO
{
    public class RssRepositoryDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(100)]
        public string CopyRight { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [StringLength(100)]
        public string Category { get; set; }

        public int ItemId { get; set; }
    }
}
