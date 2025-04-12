namespace Innosuisse.Startupticker.WebApp.Server.Data.Entities
{
    public sealed class Startup
    {
        public required Guid Id { get; set; }

        public required string Description { get; set; }
    }
}
