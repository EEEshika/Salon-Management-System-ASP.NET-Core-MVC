using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class UserDTO
    {

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Type { get; set; }

    }
}
