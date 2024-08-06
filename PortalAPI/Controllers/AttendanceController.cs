using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using System.Reflection;
using System.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendance _iattendance;
        public AttendanceController(IAttendance attendance)
        {
            _iattendance = attendance;
        }

        [HttpGet("AttendanceDataCheck/{date}/{classid}")]
        public async Task<IActionResult> AttendanceDataCheck(string date, int classid)
        {
            try
            {
                var data = await _iattendance.AttendanceDataCheckAsync(date, classid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetLatestAttendanceDate/{classid}")]
        public async Task<IActionResult> GetLatestAttendanceDate(int classid)
        {
            try
            {
                var data = await _iattendance.GetLatestAttendanceDateAsync(classid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetStudents/{classid}")]
        public async Task<IActionResult> GetStudents(int classid)
        {
            try
            {
                var data = await _iattendance.GetStudentAsync(classid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAttendanceDates/{classid}/{month}")]
        public async Task<IActionResult> GetAttendanceDates(int classid, string month)
        {
            try
            {
                var data = await _iattendance.GetAttendanceDatesAsync(classid, month);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetAttendanceDatesPerQuarter/{classid}/{quarterid}")]
        public async Task<IActionResult> GetAttendanceDatesPerQuarter(int classid, int quarterid)
        {
            try
            {
                var data = await _iattendance.GetAttendanceDatesPerQuarterAsync(classid, quarterid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetAttendanceSessions/{classid}/{studentid}/{quarterid}")]
        public async Task<IActionResult> GetAttendanceSessions(int classid, int studentid, int quarterid)
        {
            try
            {
                var data = await _iattendance.GetAttendanceSessionsAsync(classid, studentid, quarterid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAttendanceData/{studentid}/{classid}/{dates}")]
        public async Task<IActionResult> GetAttendanceData(int studentid, int classid, string dates)
        {
            try
            {
                var data = await _iattendance.GetAttendanceDataAsync(studentid, classid, dates);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetStatus")]
        public async Task<IActionResult> GetStatus()
        {
            try
            {
                var data = await _iattendance.GetStatusAsync();
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddAttendanceDate/{dates}/{classid}/{userid}")]
        public async Task<IActionResult> AddAttendanceDate(string dates,  int classid,  int userid)
        {
            try
            {
                var data = await _iattendance.AddAttendanceDateAsync(dates, classid,  userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddUpdateAttendance/{userid}")]
        public async Task<IActionResult> AddUpdateAttendance([FromBody] Attendance attendance, int userid)
        {
            try
            {
                var data = await _iattendance.AddUpdateAttendanceAsync(attendance, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetStudentsAttendance/{classid}/{month}")]
        public async Task<IActionResult> GetStudentsAttendance(int classid, string month)
        {
            try
            {
                var studentAttendance = new List<StudentAttendance>();
                var students = await _iattendance.GetStudentAsync(classid);
                if (students.IsSuccess)
                {

                    // Create a list to store the resultssjc
                   

                    // Iterate over each student
                    foreach (var student in students.Data)
                    {
                        // Read writtenOutputs for the current student
                        var attendanceOutputs = await _iattendance.GetAttendanceDatesAsync(classid, month);
                        if (attendanceOutputs.IsSuccess)
                        {
                            var attendanceOutputDict = new Dictionary<string, Attendance>();

                            // Iterate over each writtenOutput for the current student
                            foreach (var attendanceOutput in attendanceOutputs.Data)
                            {
                                // Get WrittenData for the current writtenOutput
                                var attendanceData = await _iattendance.GetAttendanceDataAsync(student.StudentID, classid, attendanceOutput);
                                // Add the writtenOutput to the dictionary
                                attendanceOutputDict.Add(attendanceOutput, attendanceData.Data);
                            }
                            // Set the WrittenOutput dictionary for the current student
                            student.AttendanceOutput = attendanceOutputDict;
                        }
                        else
                        {
                            student.AttendanceOutput = null;
                        }

                        // Add the current student to the result list
                        studentAttendance.Add(student);
                    }

                    // Create and return the StudentRecords object
                    var studentRecordsObj = new AttendanceRecord { Attendance = studentAttendance };
                    return Ok(studentRecordsObj);
                }
                else
                {
                    var studentRecordsObj = new AttendanceRecord { Attendance = studentAttendance };
                    return Ok(studentRecordsObj);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetStudentsAttendancePerQuarter/{classid}/{quarterid}")]
        public async Task<IActionResult> GetStudentsAttendancePerQuarter(int classid, int quarterid)
        {
            try
            {
                var studentAttendance = new List<StudentAttendance>();
                var students = await _iattendance.GetStudentAsync(classid);
                if (students.IsSuccess)
                {

                    // Create a list to store the resultssjc


                    // Iterate over each student
                    foreach (var student in students.Data)
                    {
                        // Read writtenOutputs for the current student
                        var attendanceOutputs = await _iattendance.GetAttendanceDatesPerQuarterAsync(classid, quarterid);
                        if (attendanceOutputs.IsSuccess)
                        {
                            var attendanceOutputDict = new Dictionary<string, Attendance>();

                            // Iterate over each writtenOutput for the current student
                            foreach (var attendanceOutput in attendanceOutputs.Data)
                            {
                                // Get WrittenData for the current writtenOutput
                                var attendanceData = await _iattendance.GetAttendanceDataAsync(student.StudentID, classid, attendanceOutput);
                                // Add the writtenOutput to the dictionary
                                attendanceOutputDict.Add(attendanceOutput, attendanceData.Data);
                            }
                            // Set the WrittenOutput dictionary for the current student
                            student.AttendanceOutput = attendanceOutputDict;
                        }
                        else
                        {
                            student.AttendanceOutput = null;
                        }

                        // Add the current student to the result list
                        studentAttendance.Add(student);
                    }

                    // Create and return the StudentRecords object
                    var studentRecordsObj = new AttendanceRecord { Attendance = studentAttendance };
                    return Ok(studentRecordsObj);
                }
                else
                {
                    var studentRecordsObj = new AttendanceRecord { Attendance = studentAttendance };
                    return Ok(studentRecordsObj);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetMonthsperClass/{classid}")]
        public async Task<IActionResult> GetMonthsperClass(int classid)
        {
            try
            {
                var data = await _iattendance.GetMonthsPerClassAsync(classid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}
