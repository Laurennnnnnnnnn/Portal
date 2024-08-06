using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {

        private readonly IClass _iclass;
        public ClassController(IClass iclass)
        {
            _iclass = iclass;
        }

        [HttpPost("AddClass/{userid}")]
        public async Task<IActionResult> AddClass(Class classdata, int userid)
        {
            try
            {
                var data = await _iclass.AddClassAsync(classdata, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAllClass/{userid}")]
        public async Task<IActionResult> GetAllClass(int userid)
        {
            try
            {
                var data = await _iclass.GetAllClassListAsync(userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetAllClass/{userid}/{schoolyearid}")]
        public async Task<IActionResult> GetClassByUserSchoolYearAsync(int userid, int schoolyearid)
        {
            try
            {
                var data = await _iclass.GetClassByUserSchoolYearAsync(userid,schoolyearid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetClassbyID/{classid}")]
        public async Task<IActionResult> GetClassbyID(int classid)
        {
            try
            {
                var data = await _iclass.GetClassListbyIDAsync(classid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateClass/{userid}")]
        public async Task<IActionResult> UpdateClass(Class classdata, int userid)
        {
            try
            {
                var data = await _iclass.UpdateClassAsync(classdata, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteClass/{userid}")]
        public async Task<IActionResult> DeleteClass(Class classdata, int userid)
        {
            try
            {
                var data = await _iclass.DeleteClassAsync(classdata.ClassID, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
