using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalRandkowy.API.Data;
using PortalRandkowy.API.Dtos;
using PortalRandkowy.API.Models;

namespace PortalRandkowy.API.Controllers {
    [Route ("api/[controller]")]
    //[ApiController]
    public class AuthController : ControllerBase {
        private readonly IAuthRepository _repository;

        public AuthController (IAuthRepository repository) {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegosterDto)
        {
            userForRegosterDto.Username = userForRegosterDto.Username.ToLower();

            if(await _repository.UserExist(userForRegosterDto.Username))
                return BadRequest("Użytkownik już istnieje.");

            var userToCreate = new User{
                Username = userForRegosterDto.Username
            };
            var createdUser = await _repository.Register(userToCreate, userForRegosterDto.Password);

            return StatusCode(201);
        }
    }
}