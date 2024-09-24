using Happy_Company_Warehouse.DataAccess.DTO;
using Happy_Company_Warehouse.DataAccess.IRepository;
using Happy_Company_Warehouse.Model;
using Happy_Company_Warehouse.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Happy_Company_Warehouse.Controllers
{
    [ApiController]
    [Route("Warehouse")]
    public class WarehouseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public WarehouseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> Index([FromQuery] FilterActivities filter)
        {
            try
            {
                var data = await _unitOfWork.Warehouses.AllAsync(filter.pageIndex, filter.pageSize);
                return Ok(data);
            }
            catch (Exception ex)
            {
                LogsServices.LogError(ex, "Catch Error:");
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] Warehouse mapperdata)
        {
            try
            {
                var result = await _unitOfWork.Warehouses.AddAsync(mapperdata);
                await _unitOfWork.Complete();
                return Ok(result);
            }
            catch (Exception ex)
            {
                LogsServices.LogError(ex, "Catch Error:");
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(  [FromBody] Warehouse mapperdata)
        {
            try
            {
                var result = _unitOfWork.Warehouses.Update(mapperdata);
                await _unitOfWork.Complete();
                return Ok(result);
            }
            catch (Exception ex)
            {
                LogsServices.LogError(ex, "Catch Error:");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromQuery] int? Id)
        {
            try
            {
                var data = await _unitOfWork.Warehouses.FindAsync(x => x.Id == Id);
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
