namespace BorrowIt.Dtos.Users;

public class UserReadDto
{
    public int Id { get; set; }
    public required string Roles { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
}