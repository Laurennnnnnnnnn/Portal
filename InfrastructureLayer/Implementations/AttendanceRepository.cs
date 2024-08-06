using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using Dapper;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InfrastructureLayer.Implementations
{
    public class AttendanceRepository : IAttendance
    {
        private readonly DapperContext _context;
        public AttendanceRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> AddAttendanceDateAsync(string dates, int classid, int userid)
        {
            var procedureName = "procAddAttendanceDates";
            var parameters = new DynamicParameters();
            parameters.Add("AttendanceDate ", DateTime.ParseExact(HttpUtility.UrlDecode(dates), "MM/dd/yyyy", null), DbType.DateTime);
            parameters.Add("ClassID ", classid, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "Add Record Failed");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<Result<Attendance>> AddUpdateAttendanceAsync(Attendance attendance, int userid)
        {
            var procedureName = "procAdUpAttendance";
            var parameters = new DynamicParameters();
            parameters.Add("AttendanceID ", attendance.AttendanceID, DbType.Int32);
            parameters.Add("StudentID ", attendance.StudentID, DbType.Int32);
            parameters.Add("ClassID ", attendance.ClassID, DbType.Int32);
            parameters.Add("QuarterID ", attendance.QuarterID, DbType.Int32);
            parameters.Add("AttendanceDate ", DateTime.ParseExact(HttpUtility.UrlDecode(attendance.AttendanceDate), "MM/dd/yyyy", null), DbType.DateTime);
            parameters.Add("StatusID ", attendance.StatusID, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryFirstOrDefaultAsync<Attendance>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData != null)
                {
                    return Result<Attendance>.Success(studentData);
                }
                else
                {
                    return Result<Attendance>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<ServiceResponse> AttendanceDataCheckAsync(string date, int classid)
        {
            var procedureName = "procAttendanceDataChecker";
            var parameters = new DynamicParameters();
            parameters.Add("AttendanceDate ", DateTime.ParseExact(HttpUtility.UrlDecode(date), "MM/dd/yyyy", null), DbType.DateTime);
            parameters.Add("ClassID ", classid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "No Record Found");
                return new ServiceResponse(true, "Exists");
            }
        }

        public async Task<Result<Attendance>> GetAttendanceDataAsync(int studentid, int classid, string dates)
        {
            var procedureName = "procGetAttendanceDatabyIDs";
            var parameters = new DynamicParameters();
            parameters.Add("StudentID ", studentid, DbType.Int32);
            parameters.Add("ClassID ", classid, DbType.Int32);
            parameters.Add("AttendanceDate ", DateTime.ParseExact(HttpUtility.UrlDecode(dates), "MM/dd/yyyy", null), DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryFirstOrDefaultAsync<Attendance>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData != null)
                {
                    return Result<Attendance>.Success(studentData);
                }
                else
                {
                    return Result<Attendance>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<List<string>>> GetAttendanceDatesAsync(int classid, string month)
        {
            var procedureName = "procGetAttendanceDates";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID", classid, DbType.Int32);
            parameters.Add("MonthIdentifier", DateTime.ParseExact(HttpUtility.UrlDecode(month), "MM/dd/yyyy", null), DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<string>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<string>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<string>>.Failure("No student records found for the provided criteria.");
                }
            }
        }
        public async Task<Result<List<string>>> GetAttendanceDatesPerQuarterAsync(int classid, int quarterid)
        {
            var procedureName = "procGetAttendanceDatesPerQuarter";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID", classid, DbType.Int32);
            parameters.Add("QuarterID", quarterid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<string>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<string>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<string>>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<LookUpSessions>> GetAttendanceSessionsAsync(int classid, int studentid, int quarterid)
        {
            var procedureName = "procGetStudentsAttendanceLookup";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID ", classid, DbType.Int32);
            parameters.Add("StudentID ", studentid, DbType.Int32);
            parameters.Add("QuarterID ", quarterid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryFirstOrDefaultAsync<LookUpSessions>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData != null)
                {
                    return Result<LookUpSessions>.Success(studentData);
                }
                else
                {
                    return Result<LookUpSessions>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<LatestDates>> GetLatestAttendanceDateAsync(int classid)
        {
            var procedureName = "procGetLatestAttendanceDate";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID ", classid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryFirstOrDefaultAsync<LatestDates>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData != null)
                {
                    return Result<LatestDates>.Success(studentData);
                }
                else
                {
                    return Result<LatestDates>.Failure("No records found");
                }
            }
        }

        public async Task<Result<List<Status>>> GetStatusAsync()
        {
            var procedureName = "procGetStatus";
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<Status>(procedureName, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<Status>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<Status>>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<List<StudentAttendance>>> GetStudentAsync(int classid)
        {
            var procedureName = "procGetAllStudentbyClass";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID", classid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<StudentAttendance>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<StudentAttendance>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<StudentAttendance>>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<List<string>>> GetMonthsPerClassAsync(int classid)
        {
            var procedureName = "procGetMonthsPerClass";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID", classid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<string>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<string>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<string>>.Failure("No records found for the provided criteria.");
                }
            }
        }
    }
}
