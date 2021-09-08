using Chirper.Data;
using Chirper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirper.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userid)
        {
            _userId = userid;
        }
        public bool CreateComment(CommentAdd model)
        {
            var entity =
                new Comment()
                {
                    UserId = _userId,
                    PostId = model.PostId,
                    Text = model.Text
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public  IEnumerable<CommentListItem> GetCommentsByPostID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.PostId == id)
                        .Select(
                        e => new CommentListItem
                        {
                            CommentId = e.Id,
                            Text = e.Text
                        }
                    );
                return  query.ToArray();
            }
        }
        public bool EditComment(CommentEdit edit)
          {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == edit.CommentId);
                entity.Text = edit.Text;
                return ctx.SaveChanges() == 1;
            }
          }
        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == commentId && e.UserId == _userId);
                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
