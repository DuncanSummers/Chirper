using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirper.Models
{
    public class CommentAdd
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage ="Comment must be at least one character long")]
        [MaxLength(281, ErrorMessage ="Comment must be at most 281 characters long")]
        public string Text { get; set; }
    }
}
