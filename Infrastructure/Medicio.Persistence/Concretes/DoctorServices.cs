using Medicio.Application.Abstractions;
using Medicio.Domain.Models;
using Medicio.Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Medicio.Persistence.Concretes
{
	public class DoctorServices : IDoctorService
	{
		AppDbContext _context;
		
		public DoctorServices(AppDbContext context)
		{
			_context = context;
		}

		public void Create(DoctorSlider doctor)
		{
			if (doctor == null) 
			{
				throw new ArgumentNullException("Something went wrong");
			}
			_context.DoctorSliders.Add(doctor);
			_context.SaveChanges();
					
		}

		public void Delete(int id)
		{
			if(id==null) 
			{
			throw new ArgumentNullException("Id wasn't found");
			}
			var doctor= _context.DoctorSliders.FirstOrDefault(x=>x.Id==id);
			_context.DoctorSliders.Remove(doctor);
			_context.SaveChanges();	
		}

        public List<DoctorSlider> GetAll()
        {
            List<DoctorSlider> doctors= _context.DoctorSliders.ToList();
			return doctors;
        }

        public void Update(DoctorSlider doctor)
		{
			var doctorup=_context.DoctorSliders.FirstOrDefault(x=>x.Id == doctor.Id);
			doctorup.Name=doctor.Name;
			doctorup.Position=doctor.Position;
			_context.SaveChanges();
		}
	}
}
