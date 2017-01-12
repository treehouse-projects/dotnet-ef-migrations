using System.ComponentModel.DataAnnotations;

namespace ComicBookGalleryModel.Models
{
    /// <summary>
    /// Represents a role.
    /// </summary>
    public class Role
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
