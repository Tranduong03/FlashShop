using FlashShop.Models;

namespace FlashShop.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Publication { get; set; }
        public float Point { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
