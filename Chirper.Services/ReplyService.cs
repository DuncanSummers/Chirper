using Chirper.Data;
using Chirper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirper.Services
{
    public class ReplyService
    {
        private readonly Guid _authorId;
        public ReplyService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                AuthorId = _authorId,
                Text = model.Text,
                CommentId = model.CommentId,
                Comment = model.Comment
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reply.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyList> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Replies
                    .Where(e => e.AuthorId == _authorId)
                        .Select(
                            e =>
                            new ReplyList
                            {
                                ReplyId = e.ReplyId,
                                Text = e.Text,
                                CommentId = e.CommentId,
                                Comment = e.Comment
                            }
                            );
                return query.ToArray();
            }
        }

        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Replies
                    .Single(e => e.ReplyId == id && e.AuthorId == _authorId);
                return new ReplyDetail
                {
                    ReplyId = entity.ReplyId,
                    Text = entity.Text,
                    CommentId = entity.CommentId,
                    Comment = entity.Comment,
                };
            }
        }
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Repliess
                    .Single(e => e.ReplyId == model.ReplyId && e.AuthorId == _authorId);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReply(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.ReplyId == replyId && e.AuthorId == _authorId);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
