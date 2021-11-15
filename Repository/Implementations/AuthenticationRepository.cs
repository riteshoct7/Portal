using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public  class AuthenticationRepository : IAuthenticationRepository
    {
        #region Fields
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        #endregion

        #region Constructors
        public AuthenticationRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        } 
        #endregion

        #region Methods

        public bool Register(ApplicationUser user, string password)
        {
            var result = userManager.CreateAsync(user, password).Result;
            if (result.Succeeded)
            {
                //string role = "User";
                //var roleResult = userManager.AddToRoleAsync(user, role).Result;
                //if (roleResult.Succeeded)
                //{
                //    return true;
                //}
                return true;
            }
            return false;
        }
        public ApplicationUser SignIn(string userName, string passowrd)
        {
            var result = signInManager.PasswordSignInAsync(userName, passowrd, false, false).Result;
            if (result.Succeeded)
            {
                var user = userManager.FindByNameAsync(userName).Result;
                //var roles = userManager.GetRolesAsync(user).Result;
                //user.Roles = roles.ToArray();
                return user;
            }
            return null;
        } 

        #endregion
    }
}
