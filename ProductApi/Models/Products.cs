namespace ProductApi.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
