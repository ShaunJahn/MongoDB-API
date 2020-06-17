#pragma checksum "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\Pages\Chat.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3dbdba3fbdb6cc4e35f2bab0157b015fe424e51"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Portal.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\_Imports.razor"
using Portal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\_Imports.razor"
using Portal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\_Imports.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\Pages\Chat.razor"
using Syncfusion.Blazor.Layouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\Pages\Chat.razor"
using Syncfusion.Blazor.Cards;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\Pages\Chat.razor"
using Syncfusion.Blazor.Lists;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\Pages\Chat.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\Pages\Chat.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\Pages\Chat.razor"
using Portal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\Pages\Chat.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Chat")]
    public partial class Chat : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 103 "C:\Users\mrjsh\Desktop\Dev\Blazor\My Portal\Portal\Pages\Chat.razor"
       
    private HubConnection hubConnection;
    int numOnline = 0;
    List<string> currentUsers = new List<string>();
    List<userMessages> userLog = new List<userMessages>();
    public List<userMessages> messageList = new List<userMessages>();
    private Dictionary<string, string> onlineUsers = new Dictionary<string, string>();
    bool chatting = false;
    private string userMessage = "";
    private string userName = "";


    protected async Task registerUser()
    {
        //step 1 connected the a Hug
        chatting = true;

        hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/chatHub"))
                .Build();

        //when something happens on a method we want to know!
        hubConnection.On<string, string>("RECEIVE", (user, newMessage) =>
        {

            messageList.Add(new userMessages()
            {
                message = newMessage,
                userName = user
            });
            StateHasChanged();
        });

        hubConnection.On<string, string, int, Dictionary<string, string>>("REGISTERED", (user, newMessage, usersOnline, userListOnline) =>
        {
            onlineUsers = userListOnline;
            numOnline = usersOnline;
            var userUpdate = new userMessages()
            {
                message = newMessage,
                userName = user
            };

            userLog.Add(userUpdate);
            StateHasChanged();
        });

        //hubConnection.On<int, Dictionary<string, string>>("UsersOnline", (numUsers, onlineUserList) =>
        //{
        //    onlineUsers = new List<userMessages>();
        //    numOnline = numUsers;
        //    foreach (var item in onlineUserList)
        //    {
        //        var userUpdate = new userMessages()
        //        {
        //            message = "",
        //            userName = item.Value
        //        };
        //        onlineUsers.Add(userUpdate);
        //    }
        //});
        //start the conenction
        await hubConnection.StartAsync();

        //when hub is connected lets let everyone know someone has joined!
        await hubConnection.SendAsync("Register", userName);
    }

    protected async Task sendMessage()
    {
        await hubConnection.SendAsync("SendMessage", userName, userMessage);
    }

    public bool IsConnected =>
    hubConnection.State == HubConnectionState.Connected;

    public void Dispose()
    {
        if (hubConnection != null)
            _ = hubConnection.DisposeAsync();
    }

    class userOnline
    {
        public string connectionId { get; set; }
    }


    public class userMessages
    {
        public string userName { get; set; }
        public string message { get; set; }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591