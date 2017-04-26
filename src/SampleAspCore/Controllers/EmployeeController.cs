using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace SampleAspCore.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Browse()
        {
            return View();
        }
    }
}
