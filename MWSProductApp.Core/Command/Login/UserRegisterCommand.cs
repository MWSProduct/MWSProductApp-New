using System;
using MediatR;
using MWSProductApp.DTO;

namespace MWSProductApp.Core.Command.Login
{
    public class UserRegisterCommand:IRequest<bool>
    {
        public MWSUserRegisterDTO mWSUserRegisterDTO { get; }
        public UserRegisterCommand(MWSUserRegisterDTO mWSUserRegisterDTO)
        {
            this.mWSUserRegisterDTO = mWSUserRegisterDTO ?? throw new ArgumentNullException(nameof(mWSUserRegisterDTO));
        }

    }
}