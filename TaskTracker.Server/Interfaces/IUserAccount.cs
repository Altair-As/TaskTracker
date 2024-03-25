using TaskTracker.Server.DataTranferObjects;
using static TaskTracker.Server.DataTranferObjects.ServerResponses;

namespace TaskTracker.Server.Interfaces
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(RegisterDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}
