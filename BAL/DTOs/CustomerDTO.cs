using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address { get; set; }

        public int? UserId { get; set; }




    }
}
