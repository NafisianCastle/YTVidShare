using System.Threading.Tasks;
using VideoSharingService.Data.DTOs;

namespace VideoSharingService.Services
{
    public class AuthManager : IAuthManager
    {
        public Task<string> CreateToken()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ValidateUser(LoginDTO userDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
