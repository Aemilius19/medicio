
using Medicio.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Medicio.Presentation.Controllers
{
	public class HomeController : Controller
	{
		IDoctorService _doctorservice;

        public HomeController(IDoctorService doctorservice)
        {
            _doctorservice = doctorservice;
        }

        public IActionResult Index()
		{
			var doctors=_doctorservice.GetAll();
			return View(doctors);
		}	
	}
}
