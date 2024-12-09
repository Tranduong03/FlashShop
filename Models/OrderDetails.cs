﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FlashShop.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string OrderCode { get; set; }
        public int BookId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("BookId")]
        public virtual BookModel Book { get; set; }
    }
}
