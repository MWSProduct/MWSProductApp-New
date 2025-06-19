using System;
using MWSProductApp.DTO;

namespace MWSProductApp.Core.Command.Login
{
    public class UserRegisterCommand
    {
        public MWSUserRegisterDTO mWSUserRegisterDTO { get; }
        public UserRegisterCommand(MWSUserRegisterDTO mWSUserRegisterDTO)
        {
            this.mWSUserRegisterDTO = mWSUserRegisterDTO ?? throw new ArgumentNullException(nameof(mWSUserRegisterDTO));
        }

    }
}