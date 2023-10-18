using OnlineStore.Data.Constants.Enums;

#nullable disable
namespace OnlineStore.Models
{
    public class NewProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Type { get; set; }
    }
}
