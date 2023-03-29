using System;
namespace PackAPI.Models
{
	public class Reply
	{
        public Guid ReplyId { get; set; }
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
        public string ReplyText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

