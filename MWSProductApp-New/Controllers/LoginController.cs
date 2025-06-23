using MediatR;
using Microsoft.AspNetCore.Mvc;
using MWSProductApp.Core.Command.Login;
using MWSProductApp.DTO;


namespace MWSProductApp.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        public readonly IMediator _mediator;    
        public LoginController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }  
        [HttpPost]
        public async Task<IActionResult> CreateMWSUser([FromBody]MWSUserRegisterDTO mWSUserRegisterDTO)
        {
            var command = new UserRegisterCommand(mWSUserRegisterDTO);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}