using Medicio.Application.Abstractions;
using Medicio.Domain.Models;
using Medicio.Persistence.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Medicio.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorSliderController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IWebHostEnvironment _environment;
        AppDbContext _context;
        public DoctorSliderController(IDoctorService doctorService,IWebHostEnvironment environment, AppDbContext context)
        {
            _doctorService = doctorService;
            _environment = environment;
            _context = context;
        }

        public IActionResult Index()
        {
            var doctors=_doctorService.GetAll();
            return View(doctors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( DoctorSlider doctor)
        {
            _doctorService.Create(doctor);
            string path = _environment.WebRootPath + @"\admin\upload\doctor\";
            string filename = doctor.ImgFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                doctor.ImgFile.CopyTo(stream);
                doctor.ImgUrl = filename;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _doctorService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) 
        {
            return View(_context.DoctorSliders.FirstOrDefault(x=>x.Id==id));
        }
        [HttpPost]
        public IActionResult Update(DoctorSlider doctor)
        {
            var updoctor = _context.DoctorSliders.FirstOrDefault(x => x.Id == doctor.Id);
            string path = _environment.WebRootPath + @"\admin\upload\doctor\";
            string filename = doctor.ImgFile.FileName;
            FileInfo file=new FileInfo(path+filename);
            if (file.Exists) { file.Delete(); }
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                doctor.ImgFile.CopyTo(stream);
                updoctor.ImgUrl = filename;
            }
            _doctorService.Update(doctor);
            return RedirectToAction("Index");
        }

    }
}
