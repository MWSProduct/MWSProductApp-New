using System;
using System.Data;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MWSProductApp.Common.Constants;
using MWSProductApp.Contract.Data.Login;
using MWSProductApp.Model;
using MWSProducts;
using MWSProductApp.DTO;
namespace MWSProductApp.Infrastructure.Repositories.Login;

public class UserRegisterRepo : IUserRepository
{
    private readonly DataDbContext _context;

    public UserRegisterRepo(DataDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public bool GetEmailId(string emailId)
    {
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = SpConstants.spCheckEmailId;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            var emailParam = new SqlParameter("@EmailId", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = emailId ?? (object)DBNull.Value
            };

            var existsParam = new SqlParameter("@Exists", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(emailParam);
            command.Parameters.Add(existsParam);
            _context.Database.OpenConnection();
            command.ExecuteNonQuery();
            var exists = (bool)existsParam.Value;
            return exists;


        }
    }

    public bool GetPhoneNumber(string PhoneNumber)
    {
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = SpConstants.spCheckPhoneNumber;
            command.CommandType = CommandType.StoredProcedure;

            var PhonenumberParam = new SqlParameter("@Phonenumber", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = PhoneNumber ?? (object)DBNull.Value
            };
            var ExistsParam = new SqlParameter("@Exists", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(PhonenumberParam);
            command.Parameters.Add(ExistsParam);
            _context.Database.OpenConnection();
            command.ExecuteNonQuery();
            var exists = (bool)ExistsParam.Value;
            return exists;

        }
        
    }
    //public void GenerateUser(MWSUserRegister mwsUserRegister)
    //{
    //    if (mwsUserRegister == null)
    //    {
    //        throw new ArgumentNullException(nameof(mwsUserRegister));
    //    }

    //    using (var command = _context.Database.GetDbConnection().CreateCommand())
    //    {
    //        command.CommandText = SpConstants.spGenerateUser;
    //        command.CommandType = CommandType.StoredProcedure;

    //        var emailParam = new SqlParameter("@EmailId", SqlDbType.VarChar)
    //        {
    //            Direction = ParameterDirection.Input,
    //            Value = mwsUserRegister.EmailId ?? (object)DBNull.Value
    //        };
    //        var phoneParam = new SqlParameter("@PhoneNumber", SqlDbType.VarChar)
    //        {
    //            Direction = ParameterDirection.Input,
    //            Value = mwsUserRegister.PhoneNumber ?? (object)DBNull.Value
    //        };
    //        var nameParam = new SqlParameter("@Name", SqlDbType.VarChar)
    //        {
    //            Direction = ParameterDirection.Input,
    //            Value = mwsUserRegister.Name ?? (object)DBNull.Value
    //        };

    //        command.Parameters.Add(emailParam);
    //        command.Parameters.Add(phoneParam);
    //        command.Parameters.Add(nameParam);

    //        _context.Database.OpenConnection();
    //        command.ExecuteNonQuery();
    //        _context.Database.CloseConnection();
    //    }
    //}
    

    public Task<object> GetAll()
    {
        throw new NotImplementedException();
    }

}
