using Chirper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirper.Models
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(281, ErrorMessage = "Too many words to reply. Shorten your reply.")]
        public string Text { get; set; }
        [Required]
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
    }
}
