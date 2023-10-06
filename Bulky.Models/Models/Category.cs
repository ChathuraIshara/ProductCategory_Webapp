using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Order should be between 1 and 100")]

        public int DisplayOrder { get; set; }
    }
}
