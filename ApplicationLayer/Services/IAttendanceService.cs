using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IAttendanceService
    {
        Task<Result<List<string>>> GetAttendanceDatesAsync(int classid, string month);
        Task<Result<List<string>>> GetAttendanceDatesPerQuarterAsync(int classid, int quarterid);
        Task<Result<List<string>>> GetMonthsPerClassAsync(int classid);
        Task<AttendanceModel> GetAllStudentsAttendanceAsync(int classid, string month);
        Task<AttendanceModel> GetAllStudentsAttendancePerQuarterAsync(int classid, int quarterid);
        Task<Result<LookUpSessions>> GetAttendanceSessionsAsync(int classid, int studentid, int quarterid);
        Task<Result<List<Status>>> GetAllStatusAsync();
        //add update attendancedata
        Task<AttendanceDataModel> AddUpdateAttendanceAsync(AttendanceOutput attendance, int userid);
        Task<MainResponseModel> AddAttendanceDatesAsync(string dates, int classid, int userid);
        Task<Result<LatestDates>> GetLatestAttendanceDateAsync(int classid);
        Task<MainResponseModel> AttendanceDataCheckAsync(string date, int classid);
    }
}
