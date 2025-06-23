using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MWSProductApp.Common.Constants;
using MWSProductApp.Contract.Data.Login;
using MWSProducts;
namespace MWSProductApp.Infrastructure.Repositories.Login;


public class UserRoleService : IUserRoleRepository
{
    private readonly DataDbContext _context;

    public UserRoleService(DataDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public Task<object> GetUserRoleById(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentException("User ID cannot be null or empty", nameof(userId));
        }
        return Task.FromResult<object>("Admin");
    }

    public Task<object> GetAllUserRoles()
    {
        return Task.FromResult<object>(new[] { "Admin", "User", "Guest" });
    }
    public void GenerateRole(string UserId, string RoleId)
    {
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = SpConstants.spGenerateRole;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            var userIdParam = new SqlParameter("@UserId", System.Data.SqlDbType.VarChar)
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = UserId ?? (object)DBNull.Value
            };
            var roleIdParam = new SqlParameter("@RoleId", System.Data.SqlDbType.VarChar)
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = RoleId ?? (object)DBNull.Value
            };
            command.Parameters.Add(userIdParam);
            command.Parameters.Add(roleIdParam);
            _context.Database.OpenConnection();
            command.ExecuteNonQuery();
            _context.Database.CloseConnection();
        }

    }   
}