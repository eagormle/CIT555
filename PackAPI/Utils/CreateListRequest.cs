using System;
namespace PackAPI.Utils
{
	public class CreateListRequest
	{
		public Guid UserId { get; set; }
		public string? ListName { get; set; }
	}
}

