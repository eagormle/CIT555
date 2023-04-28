using System;
namespace PackAPI.Utils
{
    public class CreateListBodyRequest
    {
        public Guid UserId { get; set; }
        public Guid ListId { get; set; }
        public string? ListBodyText { get; set; }
    }
}

