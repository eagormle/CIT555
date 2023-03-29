using System;
namespace PackAPI.Models
{
	public class CommentLike
	{
        public Guid CommentLikeId { get; set; }
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

