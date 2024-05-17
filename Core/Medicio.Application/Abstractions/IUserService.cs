using Medicio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicio.Application.Abstractions
{
    public interface IUserService
    {
         Task Create(User user);
        Task SignInAsync(string email, string password);
        Task CreateRoleAsync();
    }
}
