using MongoDbApp.Web.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MongoDbApp.Web.Models.Product
{
    public class ProductEditModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        [CategoryIsRequired]
        [Display(Name = "Category")]
        public string CategoryId { get; set; }
    }
}
