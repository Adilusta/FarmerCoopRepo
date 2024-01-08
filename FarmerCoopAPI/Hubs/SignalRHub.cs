using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace FarmerCoopAPI.Hubs
{
	public class SignalRHub :Hub
	{
		private readonly FarmerCoopDbContext _context;

		public SignalRHub(FarmerCoopDbContext context)
		{
			_context = context;
		}
		public async Task SendPostCount()
		{
			var value = _context.Posts.Count();
			await Clients.All.SendAsync("ReceivePostCount", value);
		}
		public async Task SendPostCountByAppUser(int userId)
		{
			var value = _context.Posts.Where(x => x.AppUserId == userId).Count();
			await Clients.All.SendAsync("ReceivePostCountByAppUser", value);
		}
		public async Task SendUserCount()
		{
			var value = _context.Users.Count();
			await Clients.All.SendAsync("ReceiveUserCount", value);
		}
		public async Task SendCommentCount()
		{
			var value = _context.Comments.Count();
			await Clients.All.SendAsync("ReceiveCommentCount", value);
		}
		public async Task SendCommentCountByAppUser(int userId)
		{
			var value = _context.Comments.Where(x=>x.AppUserID==userId).Count();
			await Clients.All.SendAsync("ReceiveCommentCountByAppUser", value);
		}
		public async Task SendProductCount()
		{
			var value = _context.Products.Count();
			await Clients.All.SendAsync("ReceiveProductCount", value);
		}
		public async Task SendProductCountByAppUser(int userId)
		{
			var value = _context.Products.Where(x => x.AppUserId == userId).Count();
			await Clients.All.SendAsync("ReceiveProductCountByAppUser", value);
		}
	}
}
