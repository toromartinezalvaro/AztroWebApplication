using AztroWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AztroWebApplication.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AztroWebApplication.Data
{
  public class UserRepository
  {
    private readonly ApplicationDbContext db;

    public UserRepository(ApplicationDbContext context)
    {
      db = context;
    }


    public async Task<List<User>> GetAllUsers()
    {
      return await db.User.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
      return await db.User.FirstOrDefaultAsync(u => u.id == id) ?? throw new KeyNotFoundException($"User with id {id} not found.");
    }

    public async Task<User> CreateUser(User user)
    {
      db.User.Add(user);
      await db.SaveChangesAsync();
      return user;
    }

    public async Task<User?> UpdateUserById(int id, User user)
    {
      var existingUser = await db.User.FindAsync(id);
      if (existingUser == null)
      {
        return null;
      }

      existingUser.name = user.name;
      existingUser.email = user.email;
      existingUser.age = user.age;

      db.User.Update(existingUser);
      await db.SaveChangesAsync();

      return existingUser;
    }

    public async Task<User?> DeleteUserById(int id)
    {
      var user = await db.User.FindAsync(id);
      if (user == null)
      {
        return null;
      }

      db.User.Remove(user);
      await db.SaveChangesAsync();

      return user;
    }
  }
}