using AccountService.API.Dtos;
using AccountService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsContoller : ControllerBase
    {
        private readonly UserRepository userRepository;

        public AccountsContoller(UserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var repository = new UserRepository();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            var result= await userRepository.Create(new Data.Entities.User
            {
                UniqueInfo=Guid.NewGuid(),
                UserName = dto.UserName,
                Password = dto.Password,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            });
            return Created("", result);
        }
    }
}

