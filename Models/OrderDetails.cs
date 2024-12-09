﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashShop.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string OrderCode { get; set; }
        public long BookId { get; set; }

        [Precision(18, 4)] 
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
