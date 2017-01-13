using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBookAverageRating
    {
        public int Id { get; set; }
        public int ComicBookId { get; set; }
        public decimal AverageRating { get; set; }
        public DateTime Date { get; set; }

        public ComicBook ComicBook { get; set; }
    }
}
