using System.Threading.Tasks;
using VideoSharingService.Data.DTOs;

namespace VideoSharingService.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO userDTO);
        Task<string> CreateToken();
    }
}
