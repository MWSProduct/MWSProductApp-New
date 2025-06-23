using System;
using MediatR;
using MWSProductApp.DTO;
using MWSProductApp.Model;

namespace MWSProductApp.Core.Command.Login
{
    public class UserRegisterCommand:IRequest<string>
    {
        public MWSUserRegisterDTO mWSUserRegister { get; }
        public UserRegisterCommand(MWSUserRegisterDTO mWSUserRegister)
        {
            this.mWSUserRegister = mWSUserRegister ?? throw new ArgumentNullException(nameof(mWSUserRegister));
        }

    }
}