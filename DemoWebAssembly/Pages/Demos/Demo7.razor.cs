using Microsoft.AspNetCore.SignalR.Client;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo7
    {
        /* Microsoft.AspNetCore.SignalR.Client */

        public HubConnection Connection { get; set; }
        public string Message { get; set; }
        public List<string> ChatMessages { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ChatMessages = new List<string>();
            //Connection au hub
            Connection = new HubConnectionBuilder().WithUrl("https://localhost:7170/chathub").Build();
            await Connection.StartAsync();

            //Abonnement à un event du hub
            Connection.On("notifyNewMessage", (string newMessage) =>
            {
                ChatMessages.Add(newMessage);
                StateHasChanged();
            });
        }

        public async Task SendMessageToHub()
        {
            //Déclenchement d'une action du hub
            await Connection.SendAsync("SendMessage", Message);
        }

        public async Task JoinGroup()
        {
            await Connection.SendAsync("JoinGroup", "monSuperGroup");
            Connection.On("notifyFrommonSuperGroup", (string message) =>
            {
                ChatMessages.Add(message);
                StateHasChanged();
            });
        }

        public async Task SendToGroup()
        {
            await Connection.SendAsync("SendToGroup", "monSuperGroup", Message);
        }

        public async Task LeaveGroup()
        {
            await Connection.SendAsync("LeaveGroup", "monSuperGroup");
        }
    }
}
