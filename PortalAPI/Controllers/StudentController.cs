using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _istudent;
        public StudentController(IStudent student)
        {
            _istudent = student;
        }
        // GET: api/<StudentController>
        [HttpGet("GetStudents/{classid}")]
        public async Task<IActionResult> GetStudents(int classid)
        {
            try
            {
                var data = await _istudent.GetAllStudentsAsync(classid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<StudentController>/5
        [HttpGet("{classid}/{studentid}")]
        public async Task<IActionResult> GetStudentbyId(int studentid, int classid)
        {
            try
            {
                var data = await _istudent.GetStudentFromClassByIdAsync(classid, studentid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<StudentController>
        [HttpPost("class/{classid}/student/{studentid}/user/{userid}")]
        //public async Task<IActionResult> AddStudent([FromBody] Student student)
        public async Task<IActionResult> AddStudent(int studentid, int classid, int userid)
        {
            try
            {
                var data = await _istudent.AddStudentoClassAsync(studentid, classid, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{userid}")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student, int userid)
        {
            try
            {
                var data = await _istudent.UpdateStudentAsync(student, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("class/{classid}/student/{studentid}/user/{userid}")]
        public async Task<IActionResult> Delete(int studentid, int classid, int userid)
        {
            try
            {
                var data = await _istudent.DeleteStudentFromClassAsync(studentid, classid , userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
