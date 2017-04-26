using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SampleAspCore.DataLayer.Entities;
using SampleAspCore.DataLayer.Interfaces;


namespace SampleAspCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Department> _repository;

        public HomeController(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var tt = _repository.All().ToList();

            //using (var dbContext = new DataContext())
            //{
            //    var tt = dbContext.Departments.ToList();
            //}
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
