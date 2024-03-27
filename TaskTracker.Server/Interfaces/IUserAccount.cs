using TaskTracker.Server.DataTranfer;
using static TaskTracker.Server.DataTranfer.ServerResponses;

namespace TaskTracker.Server.Interfaces
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(RegisterDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}
