using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace myhub.Hubs
{
    public class CommunicationHub : Hub
    {
        public async Task message(string parm1, string parm2, string parm3)
        {
            await Clients.All.SendAsync("messagereceived", parm1, parm2, parm3);
        }
        public async Task updatecustomer(string custid, string custname)
        {
            await Clients.All.SendAsync("customerupdate", custid, custname);
        }
    }

}
