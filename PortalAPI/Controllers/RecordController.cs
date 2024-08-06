using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecord _irecord;
        public RecordController(IRecord record)
        {
            _irecord = record;
        }

        [HttpGet("GetGradeRules/{initialgrade}")]
        public async Task<IActionResult> GetGradeRules(double initialgrade)
        {
            try
            {
                var data = await _irecord.GetGradeRulesAsync(initialgrade);
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
                var data = await _irecord.GetStudentAsync(classid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("GetWrittenOutput/{classid}/{quarterid}")]
        public async Task<IActionResult> GetWrittenOutput(int classid, int quarterid)
        {
            try
            {
                var data = await _irecord.GetWrittenOutputAsync(classid, quarterid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetPerformanceOutput/{classid}/{quarterid}")]
        public async Task<IActionResult> GetPerformanceOutput(int classid, int quarterid)
        {
            try
            {
                var data = await _irecord.GetPerformanceOutputAsync(classid, quarterid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetPeriodicalOutput/{classid}/{quarterid}")]
        public async Task<IActionResult> GetPeriodicalOutput(int classid, int quarterid)
        {
            try
            {
                var data = await _irecord.GetPeriodicalOutputAsync(classid, quarterid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetWrittenData/{studentid}/{writtenoutputid}")]
        public async Task<IActionResult> GetWrittenData(int studentid, int writtenoutputid)
        {
            try
            {
                var data = await _irecord.GetWrittenDataAsync(studentid, writtenoutputid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetPerformanceData/{studentid}/{performanceoutputid}")]
        public async Task<IActionResult> GetPerformanceData(int studentid, int performanceoutputid)
        {
            try
            {
                var data = await _irecord.GetPerformanceDataAsync(studentid, performanceoutputid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetPeriodicalData/{studentid}/{periodicaloutputid}")]
        public async Task<IActionResult> GetPeriodicalData(int studentid, int periodicaloutputid)
        {
            try
            {
                var data = await _irecord.GetPeriodicalDataAsync(studentid, periodicaloutputid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddWrittenOutput/{userid}")]
        public async Task<IActionResult> AddWrittenOutput(WrittenOutput output, int userid)
        {
            try
            {
                var data = await _irecord.AddWrittenOutputAsync(output, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddPerformanceOutput/{userid}")]
        public async Task<IActionResult> AddPerformanceOutput(PerformanceOutput output, int userid)
        {
            try
            {
                var data = await _irecord.AddPerformanceOutputAsync(output, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddPeriodicalOutput/{userid}")]
        public async Task<IActionResult> AddPeriodicalOutput(PeriodicalOutput output, int userid)
        {
            try
            {
                var data = await _irecord.AddPeriodicalOutputAsync(output, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateWrittenOutput/{userid}")]
        public async Task<IActionResult> UpdateWrittenOutput([FromBody] WrittenOutput writtenOutput, int userid)
        {
            try
            {
                var data = await _irecord.UpdateWrittenOutputAsync(writtenOutput, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdatePerformanceOutput/{userid}")]
        public async Task<IActionResult> UpdatePerformanceOutput([FromBody] PerformanceOutput performanceOutput, int userid)
        {
            try
            {
                var data = await _irecord.UpdatePerformanceOutputAsync(performanceOutput, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdatePeriodicalOutput/{userid}")]
        public async Task<IActionResult> UpdatePeriodicalOutput([FromBody] PeriodicalOutput periodicalOutput, int userid)
        {
            try
            {
                var data = await _irecord.UpdatePeriodicalOutputAsync(periodicalOutput, userid);
                return Ok(data);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteWritten/{writtenoutputid}/{userid}")]
        public async Task<IActionResult> DeleteWrittenOutput(int writtenoutputid, int userid)
        {
            try
            {
                var data = await _irecord.DeleteWrittenOutputAsync(writtenoutputid, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeletePerformance/{performanceoutputid}/{userid}")]
        public async Task<IActionResult> DeletePerformanceOutput(int performanceoutputid, int userid)
        {
            try
            {
                var data = await _irecord.DeletePerformanceOutputAsync(performanceoutputid, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeletePeriodical/{periodicaloutputid}/{userid}")]
        public async Task<IActionResult> DeletePeriodicalOutput(int periodicaloutputid, int userid)
        {
            try
            {
                var data = await _irecord.DeletePeriodicalOutputAsync(periodicaloutputid, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("WrittenADU/{userid}")]
        public async Task<IActionResult> WrittenDataAddUpdate([FromBody] WrittenData writtenData, int userid)
        {
            try
            {
                var data = await _irecord.WrittenDataAddUpdateAsync(writtenData, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("PerformanceADU/{userid}")]
        public async Task<IActionResult> PerformanceDataAddUpdate([FromBody] PerformanceData performanceData, int userid)
        {
            try
            {
                var data = await _irecord.PerformanceDataAddUpdateAsync(performanceData,  userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("PeriodicalADU/{userid}")]
        public async Task<IActionResult> PeriodicalDataAddUpdate([FromBody] PeriodicalData periodicalData, int userid)
        {
            try
            {
                var data = await _irecord.PeriodicalDataAddUpdateAsync(periodicalData, userid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetStudentsRecords/{classid}/{quarterid}")]
        public async Task<IActionResult> GetStudentsRecords(int classid, int quarterid)
        {

            try
            {
                var studentRecords = new List<RecordStudents>();
                var students = await _irecord.GetStudentAsync(classid);
                if (students.IsSuccess)
                {
                    // Create a list to store the resultssjc
                    

                    // Iterate over each student
                    foreach (var student in students.Data)
                    {
                        // Read writtenOutputs for the current student
                        var writtenOutputs = await _irecord.GetWrittenOutputAsync(classid, quarterid);
                        if (writtenOutputs.IsSuccess)
                        {
                            var writtenOutputDict = new Dictionary<string, WrittenOutput>();

                            // Iterate over each writtenOutput for the current student
                            foreach (var writtenOutput in writtenOutputs.Data)
                            {
                                // Get WrittenData for the current writtenOutput
                                var writtenData = await _irecord.GetWrittenDataAsync(student.StudentID, writtenOutput.WrittenOutputID);
                                writtenOutput.WrittenData = writtenData.Data;

                                // Add the writtenOutput to the dictionary
                                writtenOutputDict.Add(writtenOutput.WrittenOutputName, writtenOutput);
                            }
                            student.WrittenOutput = writtenOutputDict;
                        }
                        else { student.WrittenOutput = null; }

                        var performanceOutputs = await _irecord.GetPerformanceOutputAsync(classid, quarterid);
                        if (performanceOutputs.IsSuccess)
                        {
                            var performanceOutputDict = new Dictionary<string, PerformanceOutput>();

                            // Iterate over each writtenOutput for the current student
                            foreach (var performanceOutput in performanceOutputs.Data)
                            {
                                // Get WrittenData for the current writtenOutput
                                var performanceData = await _irecord.GetPerformanceDataAsync(student.StudentID, performanceOutput.PerformanceOutputID);
                                performanceOutput.PerformanceData = performanceData.Data;

                                // Add the writtenOutput to the dictionary
                                performanceOutputDict.Add(performanceOutput.PerformanceOutputName, performanceOutput);
                            }
                            student.PerformanceOutput = performanceOutputDict;
                        }
                        else { student.PerformanceOutput = null; }

                        var periodicalOutputs = await _irecord.GetPeriodicalOutputAsync(classid, quarterid);
                        if (periodicalOutputs.IsSuccess)
                        {
                            var periodicalOutputDict = new Dictionary<string, PeriodicalOutput>();

                            // Iterate over each writtenOutput for the current student
                            foreach (var periodicalOutput in periodicalOutputs.Data)
                            {
                                // Get WrittenData for the current writtenOutput
                                var periodiocalData = await _irecord.GetPeriodicalDataAsync(student.StudentID, periodicalOutput.PeriodicalOutputID);
                                periodicalOutput.PeriodicalData = periodiocalData.Data;

                                // Add the writtenOutput to the dictionary
                                periodicalOutputDict.Add(periodicalOutput.PeriodicalOutputName, periodicalOutput);
                            }
                            student.PeriodicalOutput = periodicalOutputDict;
                        }
                        else { student.PeriodicalOutput = null; }

                        studentRecords.Add(student);
                    }

                    // Create and return the StudentRecords object
                    var studentRecordsObj = new StudentRecords { Student = studentRecords };
                    return Ok(studentRecordsObj);
                }
                else
                {
                    // Handle the case where isSuccess is false
                    var studentRecordsObj = new StudentRecords { Student = studentRecords };
                    return Ok(studentRecordsObj);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetSummaryQuarter/{classid}")]
        public async Task<IActionResult> GetSummaryQuarter(int classid)
        {

            try
            {
                var studentRecords = new List<RecordStudents>();
                var students = await _irecord.GetStudentAsync(classid);
                if (students.IsSuccess)
                {
                    // Create a list to store the resultssjc


                    // Iterate over each student
                    foreach (var student in students.Data)
                    {
                        // Read writtenOutputs for the current student
                        student.Quarters = new Dictionary<string, Quarters>();
                        for (int i = 1; i <= 4; i++)
                        {
                            
                            Quarters quarter = new()
                            {
                                QuarterID = i,
                                Grade = 0,
                                WrittenOutput = new Dictionary<string, WrittenOutput>(),
                                PerformanceOutput = new Dictionary<string, PerformanceOutput>(),
                                PeriodicalOutput = new Dictionary<string, PeriodicalOutput>()
                            };
                            var writtenOutputs = await _irecord.GetWrittenOutputAsync(classid, i);
                            if (writtenOutputs.IsSuccess)
                            {
                                
                                var writtenOutputDict = new Dictionary<string, WrittenOutput>();

                                // Iterate over each writtenOutput for the current student
                                foreach (var writtenOutput in writtenOutputs.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var writtenData = await _irecord.GetWrittenDataAsync(student.StudentID, writtenOutput.WrittenOutputID);
                                    writtenOutput.WrittenData = writtenData.Data;

                                    // Add the writtenOutput to the dictionary
                                    writtenOutputDict.Add(writtenOutput.WrittenOutputName, writtenOutput);

                                }
                                quarter.WrittenOutput = writtenOutputDict;
                                student.WrittenOutput = writtenOutputDict;
                            }
                            else { student.WrittenOutput = null; }

                            var performanceOutputs = await _irecord.GetPerformanceOutputAsync(classid, i);
                            if (performanceOutputs.IsSuccess)
                            {
                                
                                var performanceOutputDict = new Dictionary<string, PerformanceOutput>();

                                // Iterate over each writtenOutput for the current student
                                foreach (var performanceOutput in performanceOutputs.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var performanceData = await _irecord.GetPerformanceDataAsync(student.StudentID, performanceOutput.PerformanceOutputID);
                                    performanceOutput.PerformanceData = performanceData.Data;

                                    // Add the writtenOutput to the dictionary
                                    performanceOutputDict.Add(performanceOutput.PerformanceOutputName, performanceOutput);
                                }
                                quarter.PerformanceOutput = performanceOutputDict;
                                student.PerformanceOutput = performanceOutputDict;
                            }
                            else { student.PerformanceOutput = null; }

                            var periodicalOutputs = await _irecord.GetPeriodicalOutputAsync(classid, i);
                            if (periodicalOutputs.IsSuccess)
                            {
                                
                                var periodicalOutputDict = new Dictionary<string, PeriodicalOutput>();

                                // Iterate over each writtenOutput for the current student
                                foreach (var periodicalOutput in periodicalOutputs.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var periodiocalData = await _irecord.GetPeriodicalDataAsync(student.StudentID, periodicalOutput.PeriodicalOutputID);
                                    periodicalOutput.PeriodicalData = periodiocalData.Data;

                                    // Add the writtenOutput to the dictionary
                                    periodicalOutputDict.Add(periodicalOutput.PeriodicalOutputName, periodicalOutput);
                                }
                                quarter.PeriodicalOutput = periodicalOutputDict;
                                student.PeriodicalOutput = periodicalOutputDict;
                            }
                            else { student.PeriodicalOutput = null; }


                            student.Quarters.Add($"Quarter{i}", quarter);
                        }
                        studentRecords.Add(student);
                    }

                    // Create and return the StudentRecords object
                    var studentRecordsObj = new StudentRecords { Student = studentRecords };
                    return Ok(studentRecordsObj);
                }
                else
                {
                    // Handle the case where isSuccess is false
                    var studentRecordsObj = new StudentRecords { Student = studentRecords };
                    return Ok(studentRecordsObj);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetStudentGrades/{classid}/{studentid}")]
        public async Task<IActionResult> GetStudentGrades(int classid, int studentid)
        {

            try
            {
                var studentRecords = new List<RecordStudents>();
                var students = await _irecord.GetStudentFromClassAsync(classid, studentid);
                if (students.IsSuccess)
                {
                    // Create a list to store the resultssjc


                    // Iterate over each student
                    foreach (var student in students.Data)
                    {
                        // Read writtenOutputs for the current student
                        student.Quarters = new Dictionary<string, Quarters>();
                        for (int i = 1; i <= 4; i++)
                        {

                            Quarters quarter = new()
                            {
                                QuarterID = i,
                                Grade = 0,
                                WrittenOutput = new Dictionary<string, WrittenOutput>(),
                                PerformanceOutput = new Dictionary<string, PerformanceOutput>(),
                                PeriodicalOutput = new Dictionary<string, PeriodicalOutput>()
                            };
                            var writtenOutputs = await _irecord.GetWrittenOutputAsync(classid, i);
                            if (writtenOutputs.IsSuccess)
                            {

                                var writtenOutputDict = new Dictionary<string, WrittenOutput>();

                                // Iterate over each writtenOutput for the current student
                                foreach (var writtenOutput in writtenOutputs.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var writtenData = await _irecord.GetWrittenDataAsync(student.StudentID, writtenOutput.WrittenOutputID);
                                    writtenOutput.WrittenData = writtenData.Data;

                                    // Add the writtenOutput to the dictionary
                                    writtenOutputDict.Add(writtenOutput.WrittenOutputName, writtenOutput);

                                }
                                quarter.WrittenOutput = writtenOutputDict;
                                student.WrittenOutput = writtenOutputDict;
                            }
                            else { student.WrittenOutput = null; }

                            var performanceOutputs = await _irecord.GetPerformanceOutputAsync(classid, i);
                            if (performanceOutputs.IsSuccess)
                            {

                                var performanceOutputDict = new Dictionary<string, PerformanceOutput>();

                                // Iterate over each writtenOutput for the current student
                                foreach (var performanceOutput in performanceOutputs.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var performanceData = await _irecord.GetPerformanceDataAsync(student.StudentID, performanceOutput.PerformanceOutputID);
                                    performanceOutput.PerformanceData = performanceData.Data;

                                    // Add the writtenOutput to the dictionary
                                    performanceOutputDict.Add(performanceOutput.PerformanceOutputName, performanceOutput);
                                }
                                quarter.PerformanceOutput = performanceOutputDict;
                                student.PerformanceOutput = performanceOutputDict;
                            }
                            else { student.PerformanceOutput = null; }

                            var periodicalOutputs = await _irecord.GetPeriodicalOutputAsync(classid, i);
                            if (periodicalOutputs.IsSuccess)
                            {

                                var periodicalOutputDict = new Dictionary<string, PeriodicalOutput>();

                                // Iterate over each writtenOutput for the current student
                                foreach (var periodicalOutput in periodicalOutputs.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var periodiocalData = await _irecord.GetPeriodicalDataAsync(student.StudentID, periodicalOutput.PeriodicalOutputID);
                                    periodicalOutput.PeriodicalData = periodiocalData.Data;

                                    // Add the writtenOutput to the dictionary
                                    periodicalOutputDict.Add(periodicalOutput.PeriodicalOutputName, periodicalOutput);
                                }
                                quarter.PeriodicalOutput = periodicalOutputDict;
                                student.PeriodicalOutput = periodicalOutputDict;
                            }
                            else { student.PeriodicalOutput = null; }


                            student.Quarters.Add($"Quarter{i}", quarter);
                        }
                        studentRecords.Add(student);
                    }

                    // Create and return the StudentRecords object
                    var studentRecordsObj = new StudentRecords { Student = studentRecords };
                    return Ok(studentRecordsObj);
                }
                else
                {
                    // Handle the case where isSuccess is false
                    var studentRecordsObj = new StudentRecords { Student = studentRecords };
                    return Ok(studentRecordsObj);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        //SUMMARY FOR DEVIATIONS
        [HttpGet("GetStudentsClassSummary/{classid}/{quarterid}")]
        public async Task<IActionResult> GetStudentsClassSummary(int classid, int quarterid)
        {

            try
            {
                var summaryRecords = new SummaryOutputs();
                var students = await _irecord.GetStudentAsync(classid);

                        var summarywrittenOutputDict = new Dictionary<string, SummaryWrittenOutput>();
                        // Read writtenOutputs for the current student
                        var writtenOutputs = await _irecord.GetWrittenOutputAsync(classid, quarterid);
                        if (writtenOutputs.IsSuccess)
                        {
                           
                            

                            // Iterate over each writtenOutput for the current student
                            foreach (var writtenOutput in writtenOutputs.Data)
                            {
                                int totalscore = 0;
                                int dosubmit = 0;
                                int dsntsubmit = 0;
                                int gotzero = 0;
                                List<double> scores = new();
                                foreach (var student in students.Data)
                                {
                                        // Get WrittenData for the current writtenOutput
                                        var writtenData = await _irecord.GetWrittenDataAsync(student.StudentID, writtenOutput.WrittenOutputID);
                                        if (writtenData.Data.WrittenDataID == 0)
                                        {
                                            dsntsubmit++;
                                        }
                                        else { 
                                        dosubmit++;
                                        scores.Add((double)writtenData.Data.Score);
                                        }
                                        if(writtenData.Data.WrittenDataID != 0 && writtenData.Data.Score == 0) { gotzero++; }
                                        totalscore += writtenData.Data.Score;
                                        
                                }

                                var average = dosubmit == 0 ? 0 : (double)totalscore / dosubmit;
                                double sumOfSquaresOfDifferences = 0;
                                foreach (double value in scores)
                                {
                                    double difference = value - average;
                                    double squareOfDifference = difference * difference;
                                    sumOfSquaresOfDifferences += squareOfDifference;
                                }
                                double stdDev = dosubmit == 0 ? 0 : Math.Sqrt(sumOfSquaresOfDifferences / dosubmit);
                                SummaryWrittenOutput summaryWrittenOutput = new SummaryWrittenOutput()
                                {
                                    WrittenOutputName = writtenOutput.WrittenOutputName,
                                    WrittenOutputId = writtenOutput.WrittenOutputID,
                                    totalScore = totalscore,
                                    doSubmit = dosubmit,
                                    doesntSubmit = dsntsubmit,
                                    gotZero = gotzero,
                                    maxScore = writtenOutput.MaxScore,
                                    avgScore = average,
                                    mps = (int)((((double)average) / writtenOutput.MaxScore) * 100),
                                    deviation = stdDev
                                };
                                summarywrittenOutputDict.Add(writtenOutput.WrittenOutputName, summaryWrittenOutput);
                            }

                        }
                        else {
                        summarywrittenOutputDict = new Dictionary<string, SummaryWrittenOutput>(); ;
                        }

                        var summaryperformanceOutputDict = new Dictionary<string, SummaryPerformanceOutput>();
                        // Read writtenOutputs for the current student
                        var performanceOutputs = await _irecord.GetPerformanceOutputAsync(classid, quarterid);
                        if (performanceOutputs.IsSuccess)
                        {
                            // Iterate over each writtenOutput for the current student
                            foreach (var performanceOutput in performanceOutputs.Data)
                            {
                                int totalscore = 0;
                                int dosubmit = 0;
                                int dsntsubmit = 0;
                                int gotzero = 0;
                                List<double> scores = new();
                                foreach (var student in students.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var performanceData = await _irecord.GetPerformanceDataAsync(student.StudentID, performanceOutput.PerformanceOutputID);
                                    if(performanceData.Data.PerformanceDataID == 0)
                                    {
                                        dsntsubmit++;
                                    }
                                    else { dosubmit++; scores.Add((double)performanceData.Data.Score); }
                                    if (performanceData.Data.PerformanceDataID != 0 && performanceData.Data.Score == 0) { gotzero++; }
                                    totalscore += performanceData.Data.Score;
                                }
                                var average = dosubmit == 0 ? 0 : (double)totalscore / dosubmit;
                                double sumOfSquaresOfDifferences = 0;
                                foreach (double value in scores)
                                {
                                    double difference = value - average;
                                    double squareOfDifference = difference * difference;
                                    sumOfSquaresOfDifferences += squareOfDifference;
                                }
                                double stdDev = dosubmit == 0 ? 0 : Math.Sqrt(sumOfSquaresOfDifferences / dosubmit);
                                SummaryPerformanceOutput summaryPerformanceOutput = new SummaryPerformanceOutput()
                                {
                                    PerformanceOutputName = performanceOutput.PerformanceOutputName,
                                    PerformanceOutputId = performanceOutput.PerformanceOutputID,
                                    totalScore = totalscore,
                                    doSubmit = dosubmit,
                                    doesntSubmit = dsntsubmit,
                                    gotZero = gotzero,
                                    maxScore = performanceOutput.MaxScore,
                                    avgScore = average,
                                    mps = (int)((((double)average) / performanceOutput.MaxScore) * 100),
                                    deviation = stdDev
                                };

                                // Add the writtenOutput to the dictionary
                                summaryperformanceOutputDict.Add(performanceOutput.PerformanceOutputName, summaryPerformanceOutput);
                            }

                        }
                        else
                        {
                            summaryperformanceOutputDict = new Dictionary<string, SummaryPerformanceOutput>(); ;
                        }

                        var summaryperiodicalOutputDict = new Dictionary<string, SummaryPeriodicalOutput>();
                        // Read writtenOutputs for the current student
                        var periodicalOutputs = await _irecord.GetPeriodicalOutputAsync(classid, quarterid);
                        if (periodicalOutputs.IsSuccess)
                        {
                            // Iterate over each writtenOutput for the current student
                            foreach (var periodicalOutput in periodicalOutputs.Data)
                            {
                                int totalscore = 0;
                                int dosubmit = 0;
                                int dsntsubmit = 0;
                                int gotzero = 0;
                                List<double> scores = new();
                                foreach (var student in students.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var periodicalData = await _irecord.GetPeriodicalDataAsync(student.StudentID, periodicalOutput.PeriodicalOutputID);
                                    if (periodicalData.Data.PeriodicalDataID == 0)
                                    {
                                        dsntsubmit++;
                                    }
                                    else { dosubmit++; scores.Add((double)periodicalData.Data.Score); }
                                    if (periodicalData.Data.PeriodicalDataID != 0 && periodicalData.Data.Score == 0) { gotzero++; }
                                    totalscore += periodicalData.Data.Score;
                                }
                                var average = dosubmit == 0 ? 0 : (double)totalscore / dosubmit;
                                double sumOfSquaresOfDifferences = 0;
                                foreach (double value in scores)
                                {
                                    double difference = value - average;
                                    double squareOfDifference = difference * difference;
                                    sumOfSquaresOfDifferences += squareOfDifference;
                                }
                                double stdDev = dosubmit == 0 ? 0 : Math.Sqrt(sumOfSquaresOfDifferences / dosubmit);
                                SummaryPeriodicalOutput summaryPerformanceOutput = new SummaryPeriodicalOutput()
                                {
                                    PeriodicalOutputName = periodicalOutput.PeriodicalOutputName,
                                    PeriodicalOutputId = periodicalOutput.PeriodicalOutputID,
                                    totalScore = totalscore,
                                    doSubmit = dosubmit,
                                    doesntSubmit = dsntsubmit,
                                    gotZero = gotzero,
                                    maxScore = periodicalOutput.MaxScore,
                                    avgScore = average,
                                    mps = (int)((((double)average) / periodicalOutput.MaxScore) * 100),
                                    deviation = stdDev
                                };

                                // Add the writtenOutput to the dictionary
                                summaryperiodicalOutputDict.Add(periodicalOutput.PeriodicalOutputName, summaryPerformanceOutput);
                            }

                        }
                        else
                        {
                             summaryperiodicalOutputDict = new Dictionary<string, SummaryPeriodicalOutput>(); ;
                        }

                        summaryRecords.WrittenSumOutput = summarywrittenOutputDict;
                        summaryRecords.PerformanceSumOutput = summaryperformanceOutputDict;
                        summaryRecords.PeriodicalSumOutput = summaryperiodicalOutputDict;

                    // Create and return the StudentRecords object
                    var summaryRecordsObj = new SummaryOutputs { 
                        WrittenSumOutput = summaryRecords.WrittenSumOutput,
                        PerformanceSumOutput = summaryRecords.PerformanceSumOutput,
                        PeriodicalSumOutput = summaryRecords.PeriodicalSumOutput
                    };
                    return Ok(summaryRecordsObj);
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetSummaryQuarterByStudent/{classid}/{studentid}")]
        public async Task<IActionResult> GetSummaryQuarterByStudent(int classid, int studentid)
        {

            try
            {
                
                       var studentQuarters = new Dictionary<string, Quarters>();
                        for (int i = 1; i <= 4; i++)
                        {

                            Quarters quarter = new()
                            {
                                QuarterID = i,
                                Grade = 0,
                                WrittenOutput = new Dictionary<string, WrittenOutput>(),
                                PerformanceOutput = new Dictionary<string, PerformanceOutput>(),
                                PeriodicalOutput = new Dictionary<string, PeriodicalOutput>()
                            };
                            var writtenOutputs = await _irecord.GetWrittenOutputAsync(classid, i);
                            if (writtenOutputs.IsSuccess)
                            {

                                var writtenOutputDict = new Dictionary<string, WrittenOutput>();

                                // Iterate over each writtenOutput for the current student
                                foreach (var writtenOutput in writtenOutputs.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var writtenData = await _irecord.GetWrittenDataAsync(studentid, writtenOutput.WrittenOutputID);
                                    writtenOutput.WrittenData = writtenData.Data;

                                    // Add the writtenOutput to the dictionary
                                    writtenOutputDict.Add(writtenOutput.WrittenOutputName, writtenOutput);

                                }
                                quarter.WrittenOutput = writtenOutputDict;
                                
                            }
                            var performanceOutputs = await _irecord.GetPerformanceOutputAsync(classid, i);
                            if (performanceOutputs.IsSuccess)
                            {

                                var performanceOutputDict = new Dictionary<string, PerformanceOutput>();

                                // Iterate over each writtenOutput for the current student
                                foreach (var performanceOutput in performanceOutputs.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var performanceData = await _irecord.GetPerformanceDataAsync(studentid, performanceOutput.PerformanceOutputID);
                                    performanceOutput.PerformanceData = performanceData.Data;

                                    // Add the writtenOutput to the dictionary
                                    performanceOutputDict.Add(performanceOutput.PerformanceOutputName, performanceOutput);
                                }
                                quarter.PerformanceOutput = performanceOutputDict;
                                
                            }
                            

                            var periodicalOutputs = await _irecord.GetPeriodicalOutputAsync(classid, i);
                            if (periodicalOutputs.IsSuccess)
                            {

                                var periodicalOutputDict = new Dictionary<string, PeriodicalOutput>();

                                // Iterate over each writtenOutput for the current student
                                foreach (var periodicalOutput in periodicalOutputs.Data)
                                {
                                    // Get WrittenData for the current writtenOutput
                                    var periodiocalData = await _irecord.GetPeriodicalDataAsync(studentid, periodicalOutput.PeriodicalOutputID);
                                    periodicalOutput.PeriodicalData = periodiocalData.Data;

                                    // Add the writtenOutput to the dictionary
                                    periodicalOutputDict.Add(periodicalOutput.PeriodicalOutputName, periodicalOutput);
                                }
                                quarter.PeriodicalOutput = periodicalOutputDict;
                               
                            }
                            studentQuarters.Add($"Quarter{i}", quarter);
             
                       
                    }
                    var studentQuartersObj = studentQuarters;
                    return Ok(studentQuartersObj);
                
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}
