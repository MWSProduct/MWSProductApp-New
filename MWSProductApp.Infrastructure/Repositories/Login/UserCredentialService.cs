using System;
using System;
using MWSProductApp.Contract.Data.Login;
using MWSProductApp.Model;
namespace MWSProductApp.Infrastructure.Repositories.Login;

public class UserCredentialService : IUserCredentialsRepository
{
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
    public void GenerateUserCredentials(string emailId, MWSUserRegister mwsUserRegister)
    {
        
    }
}
