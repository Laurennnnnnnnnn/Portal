using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using InfrastructureLayer.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _iuser;
        public UserController(IUser user )
        {
            _iuser = user;
        }
        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> GetStudents(string username, string password)
        {
            try
            {
                var data = await _iuser.UserLogin(username, password);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetUnverified")]
        public async Task<IActionResult> GetUnverified()
        {
            try
            {
                var data = await _iuser.GetAllUnverifiedUser();
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetVerified")]
        public async Task<IActionResult> GetVerified()
        {
            try
            {
                var data = await _iuser.GetAllVerifiedUser();
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            try
            {
                var data = await _iuser.GetCategory();
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetUserType")]
        public async Task<IActionResult> GetUserType()
        {
            try
            {
                var data = await _iuser.GetUserType();
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(User userData)
        {
            try
            {
                var data = await _iuser.AddUser(userData);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User userData)
        {
            try
            {
                var data = await _iuser.UpdateUser(userData);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("VerifyUser/{userDataid}/{userid}")]
        public async Task<IActionResult> VerifyUser(int userDataid, int userid)
        {
            try
            {
                var data = await _iuser.VerifyUser(userDataid, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("UnverifyUser/{userDataid}/{userid}")]
        public async Task<IActionResult> UnverifyUser(int userDataid, int userid)
        {
            try
            {
                var data = await _iuser.UnverifyUser(userDataid, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("DeleteUser/{userDataid}/{userid}")]
        public async Task<IActionResult> DeleteUser(int userDataid, int userid)
        {
            try
            {
                var data = await _iuser.DeleteUser(userDataid, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
