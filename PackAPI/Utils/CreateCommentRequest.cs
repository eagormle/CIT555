using System;
namespace PackAPI.Utils
{
    public class CreateCommentRequest
    {
        public Guid UserId { get; set; }
        public Guid ListId { get; set; }
        public Guid ListBodyId { get; set; }
        public String? CommentText { get; set;  }
    }
}

