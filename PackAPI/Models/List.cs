using System;
namespace PackAPI.Models
{
	public class List
	{
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
        public string ListName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

