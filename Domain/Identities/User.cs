using Domain.Common;
using System;

namespace Domain.Identities;

public class User : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Token { get; set; }
    public DateTime? TokenExpireDate { get; set; }
    public int? RoleId { get; set; }
    public Role Role { get; set; }

}
