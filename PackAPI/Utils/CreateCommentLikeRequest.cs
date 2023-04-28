using System;
namespace PackAPI.Utils
{
    public class CreateCommentLikeRequest
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
    }
}

