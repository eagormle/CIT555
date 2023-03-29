using System;
namespace PackAPI.Models
{
	public class ReplyLike
    {
        public Guid ReplyLikeId { get; set; }
        public Guid ReplyId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}


