using System.Text.Json.Serialization;

namespace TaskTracker.Server.DataTranfer
{
    public class ServerResponses
    {
        public record class GeneralResponse(bool Flag, string Message);
        public record class LoginResponse(bool Flag, string Token, string Message);

    }
}
