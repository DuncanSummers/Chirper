using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirper.Models
{
    public class ReplyList
    {
        public int ReplyId { get; set; }

        public string Text { get; set; }

        public Guid AuthorId { get; set; }

        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
