using System.ComponentModel.DataAnnotations;
using MediatR;
namespace MWSProductApp.Model
{
    public class MWSUserRegister:IRequest<string>
    {
        [Key]
        public string? UserRegisterId { get; set; }
        public string? Role { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Salutation { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Suffix { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserId { get; set; }
        public MWSSetPassword? MWSSetPassword { get; set; }

    }
}
