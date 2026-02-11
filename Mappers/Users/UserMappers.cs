namespace BorrowIt.Mappers.Users;

using BorrowIt.Dtos.Users;
using BorrowIt.Models;
using BCrypt.Net;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

public static class UserMappers
{
    public static UserReadDto ResponseUserReadDto(this User userModels)
    {
        return new UserReadDto
        {
            Id = userModels.Id,
            Username = userModels.Username,
            Email = userModels.Email
        };
    }

    public static User RequestUserCreateDto(this UserCreateDto dto)
    {
        return new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = BCrypt.HashPassword(dto.PasswordHash)
        };
    }

    public static void RequestUserUpdateDto(this User user, UserUpdateDto dto)
    {
        user.Username = dto.Username;
        user.Email = dto.Email;
    }

    public static void RequestUserChangePasswordDto(this User user, UserChangePasswordDto dto)
    {
        user.PasswordHash = BCrypt.HashPassword(dto.NewPassword);
    }
}