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
      return await db.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
      return await db.Users.FirstOrDefaultAsync(u => u.Id == id) ?? throw new KeyNotFoundException($"User with id {id} not found.");
    }

    public async Task<User> CreateUser(User user)
    {
      db.Users.Add(user);
      await db.SaveChangesAsync();
      return user;
    }

    public async Task<User?> UpdateUserById(int id, User user)
    {
      var existingUser = await db.Users.FindAsync(id);
      if (existingUser == null)
      {
        return null;
      }

      existingUser.Name = user.Name;
      existingUser.Email = user.Email;
      existingUser.Age = user.Age;

      db.Users.Update(existingUser);
      await db.SaveChangesAsync();

      return existingUser;
    }

    public async Task<User?> DeleteUserById(int id)
    {
      var user = await db.Users.FindAsync(id);
      if (user == null)
      {
        return null;
      }

      db.Users.Remove(user);
      await db.SaveChangesAsync();

      return user;
    }
  }
}