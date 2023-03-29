using System;
namespace PackAPI.Models
{
	public class ListBody
	{
        public Guid ListBodyId { get; set; }
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
        public string ListBodyText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

