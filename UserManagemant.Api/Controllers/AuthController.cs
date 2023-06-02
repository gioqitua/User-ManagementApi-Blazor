using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManagemant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration config;

        public AuthController(IConfiguration config)
        {
            this.config = config;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string userName) => Ok(JwtManager.CreateToken(userName, config));
    }
}
