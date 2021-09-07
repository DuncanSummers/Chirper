using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirper.Models
{
    public class ReplyCreate
    {
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [MaxLength(281, ErrorMessage ="Too many words to reply. Shorten your reply.")]
        public string Text { get; set; }

    }
}
