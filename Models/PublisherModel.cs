using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashShop.Models
{
    [Table("Publisher")]
    public class PublisherModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }

        [Required]
        [StringLength(200)]
        public string PublisherName { get; set; }
    }
}
