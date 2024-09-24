using Happy_Company_Warehouse.DataAccess.DTO;
using Happy_Company_Warehouse.DataAccess.IRepository;
using Happy_Company_Warehouse.Model;
using Happy_Company_Warehouse.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Happy_Company_Warehouse.Controllers
{
    [ApiController]
    [Route("Items")]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> Index([FromQuery] FilterActivities filter , int WarehouseId)
        {
            try
            {
                var data = await _unitOfWork.Items.FindAsync(x=>x.WarehouseId == WarehouseId,filter.pageIndex,filter.pageSize);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] ItemDTO data)
        {
            try
            {
                Item mapperdata = new Item
                {
                    WarehouseId = data.WarehouseId,
                    ItemName = data.ItemName,
                    SKUCode = data.SKUCode,
                    Qty = data.Qty,
                    CostPrice = data.CostPrice,
                    MSRPPrice = data.MSRPPrice
                };
                var result = await _unitOfWork.Items.AddAsync(mapperdata);
                await _unitOfWork.Complete();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(  [FromBody] ItemDTO data)
        {
            try
            {
                Item mapperdata = new Item
                {
                    Id = data.Id,
                    WarehouseId = data.WarehouseId,
                    ItemName = data.ItemName,
                    SKUCode = data.SKUCode,
                    Qty = data.Qty,
                    CostPrice = data.CostPrice,
                    MSRPPrice = data.MSRPPrice
                };
                var result = _unitOfWork.Items.Update(mapperdata);
                await _unitOfWork.Complete();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromQuery] int? Id)
        {
            try
            {
                var data = await _unitOfWork.Items.FindAsync(x => x.Id == Id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
