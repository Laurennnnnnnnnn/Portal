using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentOverallController : ControllerBase
    {
        private readonly IStudentOverall _istudentOverall;
        public StudentOverallController(IStudentOverall studentOverall)
        {
            _istudentOverall = studentOverall;
        }
        // GET: api/<StudentOverallController>
        [HttpPost("{userid}")]
        public async Task<IActionResult> AddStudent([FromBody] Student student, int userid)
        {
            try
            {
                var data = await _istudentOverall.AddStudentAsync(student, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("{userid}/{classid}")]
        public async Task<IActionResult> AddStudentAfterClass([FromBody] Student student, int userid, int classid)
        {
            try
            {
                var data = await _istudentOverall.AddStudentAfterClassAsync(student, userid, classid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("SearchStudent")]
        public async Task<IActionResult> SearchStudent(Student student)
        {
            try
            {
                var data = await _istudentOverall.SearchStudentAsync(student);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{studentid}")]
        public async Task<IActionResult> GetStudentDetails(int studentid)
        {
            try
            {
                var data = await _istudentOverall.GetStudentDetails(studentid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<StudentOverallController>/5
        [HttpPut("{userid}")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student, int userid)
        {
            try
            {
                var data = await _istudentOverall.UpdateStudentAsync(student, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<StudentOverallController>/5
        [HttpDelete("{userid}/{studentid}")]
        public async Task<IActionResult> Delete(int studentid, int userid)
        {
            try
            {
                var data = await _istudentOverall.DeleteStudentAsync(studentid, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
