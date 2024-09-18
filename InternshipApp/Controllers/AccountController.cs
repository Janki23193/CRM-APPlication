using InternshipApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace InternshipApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager; 
            _signInManager = signInManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser {UserName = model.email, Email =  model.email};
                var result = await _userManager.CreateAsync(user, model.password);

                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(loginModel.Email);
                    if (user != null)
                    {
                        return Ok(new
                        {
                            userName = user.UserName,
                            Message = "Login Successful"
                        });
                    }
                   
                }
                return Unauthorized("Invalid login attempt");
            }
            return BadRequest(ModelState);
        }
    }
}
