using AddressBook.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressBookController : ControllerBase
{
    private readonly IAddressBookService _service;

    public AddressBookController(IAddressBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contacts = await _service.GetAllAsync();
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _service.GetByIdAsync(id);

        if (contact == null)
        {
            return NotFound($"Contact with ID {id} not found.");
        }

        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        AddressBook.Models.AddressBook contact)
    {
        var createdContact = await _service.AddAsync(contact);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdContact.Id },
            createdContact);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        AddressBook.Models.AddressBook contact)
    {
        var updatedContact = await _service.UpdateAsync(id, contact);

        if (updatedContact == null)
        {
            return NotFound($"Contact with ID {id} not found.");
        }

        return Ok(updatedContact);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound($"Contact with ID {id} not found.");
        }

        return NoContent();
    }

    [HttpGet("city/{city}")]
    public async Task<IActionResult> SearchByCity(string city)
    {
        var contacts = await _service.SearchByCityAsync(city);
        return Ok(contacts);
    }

    [HttpGet("state/{state}")]
    public async Task<IActionResult> SearchByState(string state)
    {
        var contacts = await _service.SearchByStateAsync(state);
        return Ok(contacts);
    }
}