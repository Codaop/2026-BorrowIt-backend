using BorrowIt.Models;
using Microsoft.EntityFrameworkCore;

public static class UserSeeder
{
    public static void SeedUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "Admin",
                Email = "admin@example.com",
                PasswordHash = "AdminPasswordHash"
            }
        );
    }
}