namespace Innosuisse.Startupticker.WebApp.Server.Model
{
    public class ChatBotMessage
    {
        public required string SessionId { get; set; }
        public required string UserMessage { get; set; }
    }
}
