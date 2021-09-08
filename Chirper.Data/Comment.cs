using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirper.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(281, ErrorMessage ="comment too long, please be less than 281 characters")]
        public string Text { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        
        public virtual List<Reply> Replies { get; set; }
    }
}
