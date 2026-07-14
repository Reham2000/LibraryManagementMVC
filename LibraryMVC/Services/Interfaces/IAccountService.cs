using LibraryMVC.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace LibraryMVC.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterVM model);
        Task<SignInResult> Login(LoginVM model);
        Task Logout();
    }
}
