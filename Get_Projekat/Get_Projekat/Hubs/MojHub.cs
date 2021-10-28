using Get_Projekat.Models.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Get_Projekat.Hubs
{
    public class MojHub : Hub
    {
        public async Task SendMessage(string user , string message)
        {
            await Clients.All.SendAsync("RecieveMessage",user,message);
        }

        public async Task SendNoviTerminMusterija(string username, NovTermin t)
        {
            await Clients.Group("radnik").SendAsync("PrimiNovTerminMusterija",t);
        }

    }
}
