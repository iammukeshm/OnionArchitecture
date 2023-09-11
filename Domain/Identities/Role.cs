using Domain.Common;
using System.Collections.Generic;

namespace Domain.Identities;

public class Role : BaseEntity
{
    public Role()
    {
        User = new HashSet<User>();
    }
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
    public ICollection<User>User { get; set; }

}
