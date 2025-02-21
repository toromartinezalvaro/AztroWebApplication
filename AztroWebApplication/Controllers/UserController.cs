using AztroWebApplication.Services;
using AztroWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using AztroWebApplication.Data;

namespace AztroWebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly UserService userService;

  public UserController(ApplicationDbContext context)
  {
    userService = new UserService(context);
  }

  [HttpGet("all")]
  public async Task<List<User>> GetAllUsers()
  {
    return await userService.GetAllUsers();

  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUserById(int id)
  {
    var user = await userService.GetUserById(id);

    if (user == null)
    {
      return NotFound(new ErrorResponse { Message = "User not found", StatusCode = "404" });
    }

    return Ok(user);
  }

  [HttpPost]
  public async Task<IActionResult> CreateUser(User user)
  {
    var createdUser = await userService.CreateUser(user);
    if (createdUser == null)
    {
      return BadRequest(new ErrorResponse { Message = "User must be between 18 and 80 years old", StatusCode = "400" });
    }
    return Created(nameof(GetUserById), createdUser);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateUser(int id, User user)
  {
    var updatedUser = await userService.UpdateUserById(id, user);

    if (updatedUser is BadRequestObjectResult badRequestResult)
    {
      var errorMessage = badRequestResult.Value?.ToString() ?? "Unknown error";
      return BadRequest(new ErrorResponse { Message = errorMessage, StatusCode = "400" });
    }

    return Ok(updatedUser);
  }

  [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var userRemoved = await userService.DeleteUserById(id);
        if (userRemoved == null)
        return NotFound(new ErrorResponse { Message = "User not found", StatusCode = "404" });

        return Ok(new { Message = "User deleted", User = userRemoved });
    }

}
