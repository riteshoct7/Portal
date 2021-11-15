using Entities.Models;

namespace Repository.Interfaces
{
    public  interface IAuthenticationRepository
    {
        #region Methods
        bool Register(ApplicationUser user, string password);
        ApplicationUser SignIn(string userName, string passowrd); 
        #endregion

    }
}
