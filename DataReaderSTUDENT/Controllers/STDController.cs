using DataReaderSTUDENT.Model;
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

        [HttpGet("id")]
        public IActionResult Getid(int id) 
        {
            return Ok(_istudent.GetStudent(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Students students) 
        {
            _istudent.AddStudent(students);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int ID ,[FromBody] Students students)
        {
            _istudent.UpdateStudent(ID,students);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int ID)
        {
            _istudent.DeleteStudent(ID);
            return Ok();
        }
    }
}
