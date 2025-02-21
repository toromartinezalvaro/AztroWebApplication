using System.Threading.Tasks;
using AztroWebApplication.Data;
using AztroWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AztroWebApplication.Services
{
  public class UserService
  {
    private readonly UserRepository userRepository;

    public UserService(ApplicationDbContext context)
    {
      userRepository = new UserRepository(context);
    }

    public async Task<List<User>> GetAllUsers()
    {

      return await userRepository.GetAllUsers();

    }

    public async Task<User?> GetUserById(int id)
    {
      return await userRepository.GetUserById(id);

    }

    public async Task<User?> CreateUser(User user)
    {
      if (user.Age < 18 || user.Age > 80)
      {
        return null;
      }

      return await userRepository.CreateUser(user);
    }

    public async Task<IActionResult> UpdateUserById(int id, User user)
    {
      User? existingUser;
      try
      {
        existingUser = await userRepository.GetUserById(id);
      }
      catch (KeyNotFoundException)
      {
        return new NotFoundObjectResult(new ErrorResponse { Message = "User not found", StatusCode = "404" });
      }
      if (user.Age < 18 || user.Age > 80)
      {
        return new BadRequestObjectResult("Age must be between 18 and 80 years.");
      }
      var updatedUser = await userRepository.UpdateUserById(id, user);
      return new OkObjectResult(updatedUser);
    }

    public async Task<User?> DeleteUserById(int id)
    {
      return await userRepository.DeleteUserById(id);
    }

    public string SetUserStatus()
    {
      //llamar al DB para validar si existe el usuario
      //Si el usuario existe, cambiar el estado a activo
      //validar si el usuario tiene multas
      return "ok";
    }

    public Boolean CreateOrder(string order)
    {
      //llamar al DB para validar si existe el usuario
      //validad que el usuario tenga un nombre
      //validar que el usuario tenga un email
      //validar que el usuario tenga una dirección
      //validar que el usuario tenga un teléfono
      //validar que el usuario tenga un método de pago
      //validar que el usuario tenga un método de envío
      ValidateUser(new User());
      ValidateStock();

      //validad que exista stock del producto
      return true;
    }

    private string ValidateUser(User user)
    {
      //validar que el usuario tenga un nombre
      //validar que el usuario tenga un email
      //validar que el usuario tenga una dirección
      //validar que el usuario tenga un teléfono
      //validar que el usuario tenga un método de pago
      //validar que el usuario tenga un método de envío
      return "ok";
    }

    private string ValidateStock()
    {
      //validad que exista stock del producto
      return "ok";
    }
  }
}
