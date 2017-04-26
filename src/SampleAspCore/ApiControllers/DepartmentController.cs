using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SampleAspCore.DataLayer.Entities;
using SampleAspCore.DataLayer.Interfaces;

namespace SampleAspCore.ApiControllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IRepository<Department> _repository;

        public DepartmentController(IRepository<Department> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _repository.All().Select(x => x.Name);
        }

    }
}
