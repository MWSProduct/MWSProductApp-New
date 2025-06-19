using System;
using MWSProductApp.Model;
namespace MWSProductApp.Contract.Data.Login;

public interface IUserCredentialsRepository
{
    Task<MWSLogin> GetUserCredentials(string emailId);
    Task<MWSLogin> UpdateUserCredentials(string userName, string password);
    Task<MWSSetPassword> SetUserPassword(MWSSetPassword mwsSetPassword);
    void GenerateUserCredentials(string EmailId, MWSUserRegister mWSUserRegister);
    

}
