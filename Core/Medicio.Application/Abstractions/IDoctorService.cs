using Medicio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicio.Application.Abstractions
{
	public interface IDoctorService
	{
		void Create(DoctorSlider doctor);

		void Delete(int  id);

		void Update(DoctorSlider doctor);

		List<DoctorSlider> GetAll();

	}
}
