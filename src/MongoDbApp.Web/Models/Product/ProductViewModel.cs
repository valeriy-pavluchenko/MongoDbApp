namespace MongoDbApp.Web.Models.Product
{
    public class ProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
