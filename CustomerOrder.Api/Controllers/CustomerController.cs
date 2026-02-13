using CustomerOrder.Api.Pagination;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomersController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] PaginationParams pagination)
    {
        return Ok(_service.GetAll(pagination));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var customer = _service.GetById(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Create(CustomerCreateDTO dto)
    {
        _service.Create(dto);
        return Created("", dto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CustomerUpdateDTO dto)
    {
        if (!_service.Update(id, dto))
            return NotFound();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, CustomerPatchDTO dto)
    {
        if (!_service.Patch(id, dto))
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_service.Delete(id))
            return NotFound();

        return NoContent();
    }
}
