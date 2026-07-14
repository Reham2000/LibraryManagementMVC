using LibraryMVC.Models;
using LibraryMVC.Services.Interfaces;
using LibraryMVC.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace LibraryMVC.Services
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<User> _userManager;
        private readonly  SignInManager<User> _signInManager;
        public AccountService(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<SignInResult> Login(LoginVM model)
        {
            return await  _signInManager.PasswordSignInAsync(
                model.UserName, model.Password,model.RememberMe,false);
        }


        public async Task<IdentityResult> Register(RegisterVM model)
        {
            var user = new User
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,

            };

            var result = await _userManager.CreateAsync(user,model.Password);

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, "User");
            return result;


        }
        public async Task Logout()
        {
             await _signInManager.SignOutAsync();
        }
    }
}
