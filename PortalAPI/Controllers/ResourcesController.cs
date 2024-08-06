using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResources _iresources;
        public ResourcesController(IResources resources)
        {
            _iresources = resources;
        }
        // GET: api/<ResourcesController>
        [HttpPost("AddSchoolYear/{schoolyearname}")]
        public async Task<IActionResult> AddSchoolYear(string schoolyearname)
        {
            try
            {
                var data = await _iresources.AddSchoolYearAsync(schoolyearname);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddSection/{sectionname}")]
        public async Task<IActionResult> AddSection(string sectionname)
        {
            try
            {
                var data = await _iresources.AddSectionAsync(sectionname);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddSubject/{subjectname}")]
        public async Task<IActionResult> AddSubject(string subjectname)
        {
            try
            {
                var data = await _iresources.AddSubjectAsync(subjectname);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("AddQuartersDate")]
        public async Task<IActionResult> AddQuartersDate(QuartersDate date)
        {
            try
            {
                var data = await _iresources.AddQuartersDateAsync(date);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetGrades/{userlevel}")]
        public async Task<IActionResult> GetGrades(int userlevel)
        {
            try
            {
                var data = await _iresources.GetGradeAsync(userlevel);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetSchoolYear")]
        public async Task<IActionResult> GetSchoolYear()
        {
            try
            {
                var data = await _iresources.GetSchoolYearAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetSection")]
        public async Task<IActionResult> GetSection()
        {
            try
            {
                var data = await _iresources.GetSectionAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetSubject")]
        public async Task<IActionResult> GetSubject()
        {
            try
            {
                var data = await _iresources.GetSubjectAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetQuarters")]
        public async Task<IActionResult> GetQuarters()
        {
            try
            {
                var data = await _iresources.GetQuartersAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetQuartersDate/{schoolyearid}")]
        public async Task<IActionResult> GetQuartersDate(int schoolyearid)
        {
            try
            {
                var data = await _iresources.GetQuartersDateAsync(schoolyearid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateSchoolYear")]
        public async Task<IActionResult> UpdateSchoolYear(SchoolYear schoolYear)
        {
            try
            {
                var data = await _iresources.UpdateSchoolYearAsync(schoolYear);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(Subject subject)
        {
            try
            {
                var data = await _iresources.UpdateSubjectAsync(subject);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("UpdateSection")]
        public async Task<IActionResult> UpdateSection(Section section)
        {
            try
            {
                var data = await _iresources.UpdateSectionAsync(section);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateQuartersDate")]
        public async Task<IActionResult> UpdateQuartersDate(QuartersDate date)
        {
            try
            {
                var data = await _iresources.UpdateQuartersDateAsync(date);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteSection/{sectionid}/{userid}")]
        public async Task<IActionResult> DeleteSection(int sectionid, int userid)
        {
            try
            {
                var data = await _iresources.DeleteSectionAsync(sectionid, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("DeleteSubject/{subjectid}/{userid}")]
        public async Task<IActionResult> DeleteSubject(int subjectid, int userid)
        {
            try
            {
                var data = await _iresources.DeleteSubjectAsync(subjectid, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("DeleteSchoolYear/{schoolyearid}/{userid}")]
        public async Task<IActionResult> DeleteSchoolYear(int schoolyearid, int userid)
        {
            try
            {
                var data = await _iresources.DeleteSchoolYearAsync(schoolyearid, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("DeleteQuartersDate/{quartersdateid}/{userid}")]
        public async Task<IActionResult> DeleteQuartersDate(int quartersdateid, int userid)
        {
            try
            {
                var data = await _iresources.DeleteQuartersDateAsync(quartersdateid, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetWeightedScore/{classid}/{schoolyearid}")]
        public async Task<IActionResult> GetQuarters(int classid, int schoolyearid)
        {
            try
            {
                var data = await _iresources.GetWeightedScoreAsync(classid, schoolyearid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetOutputs")]
        public async Task<IActionResult> GetOutputs()
        {
            try
            {
                var data = await _iresources.GetOutputsAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("AddWeighted")]
        public async Task<IActionResult> AddWeightedYear(WeightedScore score)
        {
            try
            {
                var data = await _iresources.AddWeightedAsync(score);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateWeighted")]
        public async Task<IActionResult> UpdateWeightedYear(WeightedScore score)
        {
            try
            {
                var data = await _iresources.UpdateWeightedAsync(score);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteWeighted/{weightedscoreid}/{userid}")]
        public async Task<IActionResult> DeleteWeightedYear(int weightedscoreid, int userid)
        {
            try
            {
                var data = await _iresources.DeleteWeightedAsync(weightedscoreid, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
