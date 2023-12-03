using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace forthekittens_razor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("Category Name")]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 10)]
        public int DisplayOrder { get; set; }

    }
}
