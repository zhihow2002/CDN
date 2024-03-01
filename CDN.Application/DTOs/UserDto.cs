namespace CDN.Application.DTOs;
public class UserDto
{
    public int Id { get; set; } // Used for update and delete operations
    public string Username { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string Skillsets { get; set; }
    public string Hobby { get; set; }
}
