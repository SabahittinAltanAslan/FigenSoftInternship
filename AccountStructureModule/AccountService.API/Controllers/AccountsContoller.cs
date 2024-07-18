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
        public async Task<IActionResult> GetAll()
        {
            var result = await userRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            var result = await userRepository.Create(new Data.Entities.User
            {
                UniqueInfo = Guid.NewGuid(),
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

        [HttpGet("uniqueInfo")]
        public async Task<IActionResult> GetByUniqueInfo(Guid uniqueInfo)
        {
            var result = await userRepository.GetByUniqueInfo(uniqueInfo);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto dto)
        {
            await userRepository.Update(new Data.Entities.User
            {
                UserName = dto.UserName,
                Password = dto.Password,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            });

            return NoContent();
        }

        [HttpDelete("uniqueInfo")]
        public async Task<IActionResult> Delete(Guid uniqueInfo)
        {
            await userRepository.Remove(uniqueInfo);
            return NoContent();
        }

    }
}

