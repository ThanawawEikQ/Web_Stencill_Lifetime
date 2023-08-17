using Microsoft.AspNetCore.SignalR;

namespace Web_Stencill_Lifetime.Data
{
	public class AutoRefreshHub	:Hub
	{
		public async Task SendRefresh()
		{
			await Clients.All.SendAsync("Refresh");
		}
	}
}
