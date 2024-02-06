using DataReaderSTUDENT.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataReaderSTUDENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class STDController : ControllerBase
    {
        private readonly IStudent _istudent;
        public STDController(IStudent student)
        {
            _istudent = student;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_istudent.GetAllStudents());
        }
    }
}
