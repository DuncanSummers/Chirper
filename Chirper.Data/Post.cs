using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirper.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        [MaxLength(32, ErrorMessage ="Keep post titles under 32 characters")]
        public string Title { get; set; }
        [Required]
        [MaxLength(281, ErrorMessage ="Text exceeds the 281 character limit")]
        public string Text { get; set; }
        public virtual List<Comment> Comments { get; set;}
        public Guid AuthorId { get; set; }
    }
}
