using System;
using MWSProductApp.Model;

namespace MWSProductApp.Contract.Data.Login;

public interface IRoleRepository
{
    Task<MWSRoles> GetAllRoles();
    Task<MWSRoles> UpdateRole(string roleId);
    Task<MWSRoles> AddRole(MWSRoles mwsRoles);
    Task<MWSRoles> DeleteRole(string roleId);
}
