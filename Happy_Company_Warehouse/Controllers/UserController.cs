using Happy_Company_Warehouse.DataAccess.DTO;
using Happy_Company_Warehouse.DataAccess.IRepository;
using Happy_Company_Warehouse.DataAccess.Services;
using Happy_Company_Warehouse.DataAccess.Settings.Models;
using Microsoft.AspNetCore.Mvc;
using THappy_Company_Warehouse.DataAccess.Services;

namespace Happy_Company_Warehouse.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        public UserController(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;

        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _authService.AddUserAsync(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                LogsServices.LogError(e, "Catch Error:");
                return BadRequest(new
                {
                    message = e.Message
                });
            }
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> Index([FromQuery] FilterActivities filter)
        {
            try
            {
                var data = await _authService.GetAllUsers(filter);
                return Ok(data);
            }
            catch (Exception ex)
            {
                LogsServices.LogError(ex, "Catch Error:");
                return BadRequest(ex.Message);
            }
        }

    }
}
