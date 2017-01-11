using System.ComponentModel.DataAnnotations;

namespace MongoDbApp.Web.Models.Category
{
    public class CategoryEditModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
