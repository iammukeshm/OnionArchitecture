using Domain.Entities;
using Domain.Identities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<User>Users { get; set; }
        DbSet<Role> Roles { get; set; }

        Task<int> SaveChangesAsync();
    }
}
