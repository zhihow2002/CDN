using CDN.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CDN.Application.DTOs;

namespace CDN.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> Get(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Post([FromBody] UserDto userDto)
    {
        var newUser = await _userService.CreateUserAsync(userDto);
        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UserDto userDto)
    {
        await _userService.UpdateUserAsync(id, userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }
}
