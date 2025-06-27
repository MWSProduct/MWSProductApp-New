using System;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MWSProductApp.Common.Constants;
using MWSProductApp.Contract.Data.Login;
using MWSProductApp.DTO;
using MWSProductApp.Model;
using MWSProducts;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
namespace MWSProductApp.Infrastructure.Repositories.Login;

public class UserCredentialService : IUserCredentialsRepository
{
    private readonly DataDbContext _context;
    public readonly IMapper _mapper;
    private readonly IPasswordHasher<MWSUserCredentialDTO> _passwordHasher;

    public UserCredentialService(DataDbContext context, IPasswordHasher<MWSUserCredentialDTO> passwordHandler,IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _passwordHasher = passwordHandler ?? throw new ArgumentNullException(nameof(passwordHandler));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
        var userRegisterDTO = new MWSUserRegisterDTO();
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

            command.Parameters.Add(userDetails);
            command.Parameters.Add(exsitsRegister);
            _context.Database.OpenConnection();
            command.ExecuteNonQuery();
            userRegisterDTO = GetUserDetails(mWSUserRegister.EmailAddress);

            GenerateUserLoginData(userRegisterDTO,mWSUserRegister.MWSSetPassword.Password);


        }

    }
    public void GenerateUserLoginData(MWSUserRegisterDTO mWSUserCredentialDTO,string Password)
    {
        if (mWSUserCredentialDTO == null)
        {
            throw new ArgumentNullException(nameof(mWSUserCredentialDTO));
        }

        var userCredentials = new MWSUserCredentialDTO
        {
            UserGuid = mWSUserCredentialDTO.UserGuid,
            EmailAddress=mWSUserCredentialDTO.EmailAddress            
        };
        var PasswordHasher = _passwordHasher.HashPassword(userCredentials, Password);
        userCredentials.Password = PasswordHasher;

        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = SpConstants.spGenerateUserCredentials;
            command.CommandType = CommandType.StoredProcedure;

            string JsonData = JsonConvert.SerializeObject(mWSUserCredentialDTO);
            var userDetails = new SqlParameter("@Json", SqlDbType.NVarChar)
            {
                Direction = ParameterDirection.Input,
                Value = JsonData ?? (object)DBNull.Value
            };
            command.Parameters.Add(userDetails);
            _context.Database.OpenConnection();
            command.ExecuteNonQuery();
        }

    }
    public MWSUserRegisterDTO GetUserDetails(string emailId)
    {
        var userDetails = new MWSUserRegister();
        if (string.IsNullOrEmpty(emailId))
        {
            throw new ArgumentNullException(nameof(emailId));
        }
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = SpConstants.spGetUserDetails;
            command.CommandType = CommandType.StoredProcedure;
            var emailparam = new SqlParameter("@EmailId", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = emailId ?? (object)DBNull.Value
            };
            command.Parameters.Add(emailparam);
            _context.Database.OpenConnection();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    userDetails= new MWSUserRegister
                    {
                        UserGuid = reader["UserGuid"] as string,
                        FirstName = reader["FirstName"] as string,
                        MiddleName = reader["MiddleName"] as string,
                        LastName = reader["LastName"] as string,
                        Salutation = reader["Salutation"] as string,
                        DateOfBirth = reader["DateOFBirth"] as string,
                        Suffix = reader["Suffix"] as string,
                        Gender = reader["Gender"] as string,
                        MaritalStatus = reader["MaritalStatus"] as string,
                        EmailAddress = reader["EmailAddress"] as string,
                        PhoneNumber = reader["PhoneNumber"] as string,
                    };

                }
            }

        }
        var dtolist = _mapper.Map<MWSUserRegisterDTO>(userDetails);
        return dtolist;
    }
}
