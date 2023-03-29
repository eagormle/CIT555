using System;
namespace PackAPI.Models
{
	public class Comment
	{
        public Guid CommentId { get; set; }
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
        public Guid ListBodyId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

