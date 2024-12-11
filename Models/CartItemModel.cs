namespace FlashShop.Models
{
    public class CartItemModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total 
        {
            get { return Quantity * Price; }
        }
        public string Image {  get; set; }

        public CartItemModel()
        {
               
        }
        public CartItemModel(BookModel book)
        {
            BookId = book.BookId;
            Title = book.Title;
            Quantity = 1;
            Price = book.Price;
            Image = book.ImgLink;
        }
        
    }
}
