
using Microsoft.AspNetCore.Mvc;
using MusicApp.Entities;
using MusicApp.WebApi.DTO;
using System.Threading.Tasks;
using MusicApp.WebApi.Repositories;
using AutoMapper;

namespace MusicApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountsController(IAccountRepository accountRepository,
                                    IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel signUpModel)
        {
            var user = _mapper.Map<ApplicationUser>(signUpModel);
            var result = await _accountRepository.SignUpAsync(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]SignInModel signInModel)
        {
            var result = await _accountRepository.LoginAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

    }
}
