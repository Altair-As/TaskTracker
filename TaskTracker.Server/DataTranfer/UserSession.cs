namespace TaskTracker.Server.DataTranfer
{
    public record UserSession(string ? Id, string ? Name, string ? Email, string ? Role);
}
