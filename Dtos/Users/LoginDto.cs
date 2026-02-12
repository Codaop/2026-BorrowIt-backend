using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BorrowIt.Dtos.Users;

public class LoginDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}