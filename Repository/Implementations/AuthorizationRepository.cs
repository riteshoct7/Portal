using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        #region Fields

        private readonly RoleManager<ApplicationRole> roleManager; 

        #endregion

        #region Constructors
        public AuthorizationRepository(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        #endregion

        #region Methods
        public async Task<bool> AddRole(ApplicationRole obj)
        {
            var result = await roleManager.CreateAsync(obj);
            return result.Succeeded;
        }

        public bool CheckRoleExist(string roleName)
        {
            return roleManager.RoleExistsAsync(roleName).Result;
            
        } 
        #endregion
    }
}
