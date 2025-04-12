namespace Innosuisse.Startupticker.WebApp.Server.Data.Entities
{
    public sealed class StartupTag
    {
        public required Guid StartupId { get; set; }
        public required string Name { get; set; }

        // nav props
        public Startup? Startup { get; set; }
    }
}
