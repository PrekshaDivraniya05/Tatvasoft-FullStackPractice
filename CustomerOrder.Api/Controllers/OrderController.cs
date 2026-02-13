using CustomerOrder.Api.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    // [HttpGet]
    // public IActionResult GetAll()
    // {
    //     return Ok(_service.GetAll());
    // }

    // [HttpGet("{id}")]
    // public IActionResult GetById(int id)
    // {
    //     var order = _service.GetById(id);
    //     if (order == null) return NotFound();
    //     return Ok(order);
    // }

    // [HttpPost]
    // public IActionResult Create(OrderCreateDTO dto)
    // {
    //     if (!_service.Create(dto))
    //         return BadRequest("Customer does not exist.");

    //     return Created("", dto);
    // }

    // [HttpPut("{id}")]
    // public IActionResult Update(int id, OrderUpdateDTO dto)
    // {
    //     if (!_service.Update(id, dto))
    //         return NotFound();

    //     return NoContent();
    // }

    // [HttpPatch("{id}")]
    // public IActionResult Patch(int id, OrderPatchDTO dto)
    // {
    //     if (!_service.Patch(id, dto))
    //         return NotFound();

    //     return NoContent();
    // }

    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {
    //     if (!_service.Delete(id))
    //         return NotFound();

    //     return NoContent();
    // }

    [HttpPost]
    public IActionResult CreateOrder(OrderCreateDTO dto)
    {
        if(!_service.Create(dto))
            return BadRequest("No customer exist");
        return Created("",dto);
    }

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) 
    {
        var order = _service.GetById(id);
        if(order == null) return NotFound();
        return Ok(order);
    }

    [HttpPut("{id}")]

    public IActionResult UpdateOrder(int id, OrderUpdateDTO dto)
    {
        if(!_service.Update(id,dto)) return NotFound();

        return NoContent();
    }

    [HttpPatch("{id}")]

    public IActionResult PatchOrder(int id, OrderPatchDTO dto)
    {
        if(!_service.Patch(id,dto)) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteOrder(int id)
    {
        if(!_service.Delete(id)) return NotFound();

        return NoContent();
    }


    [HttpGet]
    [Route("getorders/{customerId}")]

    public IActionResult GetOrdersByCustomerId(int customerId)
    {
        var orders = _service.GetOrdersByCustomerId(customerId);
        return Ok(orders);
    }
}
