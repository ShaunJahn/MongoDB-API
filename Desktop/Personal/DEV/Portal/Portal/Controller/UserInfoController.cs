using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Portal.Data;
using Portal.Hubs;
using Portal.Models;

namespace Portal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private IHubContext<ChatHub> _hubcontext;
        private ApplicationDbContext _context;

        public UserInfoController(IHubContext<ChatHub> hubcontext, ApplicationDbContext applicationDbContext)
        {
            _hubcontext = hubcontext;
            _context = applicationDbContext;
        }
        [HttpPost]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public async Task SaveUserChatLog(groupChatLog groupChatLog)
        {
            //await this._hubcontext.Clients.All.SendAsync("OnlineUsers", 10);
            await _context.AddAsync(new groupChatLog() { connectionId = groupChatLog.connectionId } );
            await _context.SaveChangesAsync();
            var value = Request.Cookies[".AspNetCore.Identity.Application"];
            await _hubcontext.Clients.All.SendAsync("userLog", groupChatLog.connectionId);
        }
    }
}
