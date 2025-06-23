using MediatR;
using MWSProductApp.Core.Command.Login;
using MWSProductApp.DTO;
using MWSProductApp.Model;
using MWSProductApp.Contract.Data.Login;

namespace MWSProductApp.Core.Handler
{
    public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserCredentialsRepository _userCredentialsRepository;
        public UserRegisterHandler(IUserRepository userRepository,IUserCredentialsRepository userCredentialsRepository)
        {
            _userRepository = userRepository;
            _userCredentialsRepository = userCredentialsRepository;
        }
        public Task<string> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            MWSUserRegisterDTO mWSUserRegisterDTO = request.mWSUserRegister;
            var MWSUserProfile = new MWSUserRegister
            {
                UserName = mWSUserRegisterDTO.UserName,
                EmailAddress = mWSUserRegisterDTO.EmailAddress,
                PhoneNumber = mWSUserRegisterDTO.PhoneNumber,
                DateOfBirth = mWSUserRegisterDTO.DateOfBirth
            };
            var existingEmailAddress = _userRepository.GetEmailId(MWSUserProfile.EmailAddress);
            var existingPhoneNumber = _userRepository.GetPhoneNumber(MWSUserProfile.PhoneNumber);
            _userCredentialsRepository.GenerateUserCredentials(MWSUserProfile.EmailAddress, mWSUserRegisterDTO);
            return Task.FromResult(MWSUserProfile.UserName??string.Empty);



        }
    }
}