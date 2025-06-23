using System;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MWSProductApp.Common.Constants;
using MWSProductApp.Contract.Data.Login;
using MWSProductApp.DTO;
using MWSProductApp.Model;
using MWSProducts;
using Newtonsoft.Json;
namespace MWSProductApp.Infrastructure.Repositories.Login;

public class UserCredentialService : IUserCredentialsRepository
{
    private readonly DataDbContext _context;

    public UserCredentialService(DataDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public Task<MWSLogin> GetUserCredentials(string emailId)
    {
        throw new NotImplementedException();
    }

    public Task<MWSLogin> UpdateUserCredentials(string userName, string password)
    {
        throw new NotImplementedException();
    }

    public Task<MWSSetPassword> SetUserPassword(MWSSetPassword mwsSetPassword)
    {
        throw new NotImplementedException();
    }
   public void GenerateUserCredentials(string emailId, MWSUserRegisterDTO mWSUserRegister)
    {
        if (string.IsNullOrEmpty(emailId))
        {
            throw new ArgumentNullException(nameof(emailId));
        }
        if (mWSUserRegister == null)
        {
            throw new ArgumentNullException(nameof(mWSUserRegister));
        }
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = SpConstants.spGenerateUserDetails;
            command.CommandType = CommandType.StoredProcedure;

            string JsonData = JsonConvert.SerializeObject(mWSUserRegister);
            var userDetails = new SqlParameter("@json", SqlDbType.NVarChar)
            {
                Direction = ParameterDirection.Input,
                Value = JsonData ?? (object)DBNull.Value
            };
            var exsitsRegister = new SqlParameter("@ExistsRegister", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output

            };
            var exsitsPassWord = new SqlParameter("@ExistsPassword", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output

            };
            command.Parameters.Add(userDetails);
            command.Parameters.Add(exsitsRegister);
            command.Parameters.Add(exsitsPassWord);
            _context.Database.OpenConnection();
            command.ExecuteNonQuery();
            var existsRegister = (bool)exsitsRegister.Value;
            var existsPassword = (bool)exsitsPassWord.Value;
            

        }       
    }
}
