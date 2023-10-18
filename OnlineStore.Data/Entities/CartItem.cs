using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Data.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
