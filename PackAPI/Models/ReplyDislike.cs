using System;
namespace PackAPI.Models
{
	public class ReplyDislike
	{
        public Guid ReplyDislikeId { get; set; }
        public Guid ReplyId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

