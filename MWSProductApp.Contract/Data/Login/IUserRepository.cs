using System;
using MWSProductApp.Model;
namespace MWSProductApp.Contract.Data.Login;

public interface IUserRepository
{
    bool GetEmailId(string emailId);
    bool GetPhoneNumber(string PhoneNumber);
    Task<object> GetAll();
    //void GenerateUser(MWSUserRegister mwsUserRegister);

}
