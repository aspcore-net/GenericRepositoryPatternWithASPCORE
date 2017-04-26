using Microsoft.AspNetCore.Mvc;
using SampleAspCore.DataLayer.Entities;
using SampleAspCore.DataLayer.Interfaces;
using SampleAspCore.Helpers;
using SampleAspCore.Models;

namespace SampleAspCore.ApiControllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Pager<Employee> Get(Pager<Employee> pager)
        {
            //filling records
            EmployeeModel.Fill(_repository, pager);
            //returning response
            return pager;
        }
    }
}
