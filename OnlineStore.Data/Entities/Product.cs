using OnlineStore.Data.Constants.Enums;
using System.ComponentModel.DataAnnotations;

#nullable disable
namespace OnlineStore.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageName { get; set; }
        public bool IsBestseller { get; set; }
    }
}
