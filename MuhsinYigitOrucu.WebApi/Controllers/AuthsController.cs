using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.Dtos.AuthsDtos;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var loginUserCheck = await _userManager.FindByEmailAsync(dto.Email!);
            var userRole = await _userManager.GetRolesAsync(loginUserCheck!);
            if (loginUserCheck == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Kullanıcı adı veya şifre hatalı."
                });
            }

            var user = await _signInManager.CheckPasswordSignInAsync(loginUserCheck, dto.Password!, false);

            if (!user.Succeeded)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Kullanıcı adı veya şifre hatalı."
                });
            }

            return Ok(new
            {
                Success = true,
                UserName = loginUserCheck.UserName,
                Email = loginUserCheck.Email,
                Id = loginUserCheck.Id,
                NameSurname = loginUserCheck.NameSurname,
                Role = userRole.FirstOrDefault()
            });
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Oturum başarıyla kapatıldı." });
        }
    }
}
