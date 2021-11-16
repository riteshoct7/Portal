using Entities.Models;

namespace Repository.Interfaces
{
    public interface IAuthorizationRepository
    {
        #region Methods

        bool CheckRoleExist(string roleName);

        Task<bool> AddRole(ApplicationRole obj);

        List<ApplicationRole> GetAllRoles();

        #endregion
    }
}
