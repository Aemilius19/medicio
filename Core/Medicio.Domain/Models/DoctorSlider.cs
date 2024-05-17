

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicio.Domain.Models
{
	public class DoctorSlider
	{
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Name  { get; set; }
		[Required]
		[MinLength(1)]
		[MaxLength(255)]
		public string Position { get; set; }
		[MinLength(1)]
		[MaxLength(255)]
		public string? ImgUrl { get; set; }
		[NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
