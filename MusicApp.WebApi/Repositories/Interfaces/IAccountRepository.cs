using Microsoft.AspNetCore.Identity;
using MusicApp.Entities;
using MusicApp.WebApi.DTO;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(ApplicationUser applicationUser);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}