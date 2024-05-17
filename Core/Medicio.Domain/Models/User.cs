using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicio.Domain.Models
{
	public class User:IdentityUser
	{
        public string Name { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password),Compare(nameof(password))]
        public string currentpassword { get; set; }
    }
}
