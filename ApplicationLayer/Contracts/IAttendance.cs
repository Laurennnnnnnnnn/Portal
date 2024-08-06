using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contracts
{
    public interface IAttendance
    {
        //COMPLEX RESPONSE

        //get student list for attendance records
        Task<Result<List<StudentAttendance>>> GetStudentAsync(int classid);
        //get dates by Classid
        Task<Result<List<string>>> GetAttendanceDatesAsync(int classid, string month);
        Task<Result<List<string>>> GetAttendanceDatesPerQuarterAsync(int classid, int quarterid);
        Task<Result<List<string>>> GetMonthsPerClassAsync(int classid);
        //get attendancedata by each student and dates
        Task<Result<Attendance>> GetAttendanceDataAsync(int studentid, int classid, string dates);
        Task<Result<LookUpSessions>> GetAttendanceSessionsAsync(int classid, int studentid, int quarterid);
        //get all status
        Task<Result<List<Status>>> GetStatusAsync();
        



        //SINGLE RESPONSE


        //add dates
        Task<ServiceResponse> AddAttendanceDateAsync(string dates, int classid, int userid);
        //add update attendancedata
        Task<Result<Attendance>> AddUpdateAttendanceAsync(Attendance attendance, int userid);
        Task<Result<LatestDates>> GetLatestAttendanceDateAsync(int classid);
        Task<ServiceResponse> AttendanceDataCheckAsync(string date, int classid);
      
    }
}
