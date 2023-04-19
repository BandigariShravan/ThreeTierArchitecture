using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_DAL.Models
{
    public class BookUser
    {
        [Key]
        public int BookUserId { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }

        //[JsonIgnore]
        //public virtual Book Book { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        
        //[JsonIgnore]
        //public virtual User user { get; set; }
    }
}