using System;
namespace PackAPI.Models
{
	public class CommentDislike
	{
        public Guid CommentDislikeId { get; set; }
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

