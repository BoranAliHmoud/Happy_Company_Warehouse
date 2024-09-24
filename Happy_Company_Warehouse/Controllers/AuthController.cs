using Happy_Company_Warehouse.DataAccess.IRepository;
using Happy_Company_Warehouse.DataAccess.Services;
using Happy_Company_Warehouse.DataAccess.Settings.Models;
using Microsoft.AspNetCore.Mvc;

namespace Happy_Company_Warehouse.Controllers
{
    [ApiController]
    [Route("User")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        public AuthController(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;

        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model); 
            return Ok(result);
        }
    }
}
