using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApplicationLayer.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly HttpClient _httpClient;
        public AttendanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MainResponseModel> AddAttendanceDatesAsync(string dates, int classid, int userid)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Attendance/AddAttendanceDate/{Uri.EscapeDataString(dates)}/{classid}/{userid}", new StringContent(""));
            var response = await data.Content.ReadFromJsonAsync<MainResponseModel>();
            return response!;
        }

        public async Task<AttendanceDataModel> AddUpdateAttendanceAsync(AttendanceOutput attendance, int userid)
        {
            
            var data = await _httpClient.PostAsJsonAsync($"api/Attendance/AddUpdateAttendance/{userid}", attendance);
            var response = await data.Content.ReadFromJsonAsync<AttendanceDataModel>();
            return response!;
        }

        //public async Task<AttendanceModel> GetAllStudentsAsync(int classid)
        //{
        //    var data = await _httpClient.GetFromJsonAsync<AttendanceModel>($"api/Attendance/GetStudents/{classid}");
        //    return data;
        //}
        public async Task<Result<List<Status>>> GetAllStatusAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<Status>>>($"api/Attendance/GetStatus");
            return data;
        }

        public async Task<AttendanceModel> GetAllStudentsAttendanceAsync(int classid, string month)
        {
            var data = await _httpClient.GetFromJsonAsync<AttendanceModel>($"api/Attendance/GetStudentsAttendance/{classid}/{Uri.EscapeDataString(month)}");
            return data;
        }
        public async Task<AttendanceModel> GetAllStudentsAttendancePerQuarterAsync(int classid, int quarterid)
        {
            var data = await _httpClient.GetFromJsonAsync<AttendanceModel>($"api/Attendance/GetStudentsAttendancePerQuarter/{classid}/{quarterid}");
            return data;
        }

        public async Task<Result<List<string>>> GetAttendanceDatesAsync(int classid, string month)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<string>>>($"api/Attendance/GetAttendanceDates/{classid}/{Uri.EscapeDataString(month)}");
            return data;
        }
        public async Task<Result<List<string>>> GetAttendanceDatesPerQuarterAsync(int classid, int quarterid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<string>>>($"api/Attendance/GetAttendanceDatesPerQuarter/{classid}/{quarterid}");
            return data;
        }

        public async Task<Result<LatestDates>> GetLatestAttendanceDateAsync(int classid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<LatestDates>>($"api/Attendance/GetLatestAttendanceDate/{classid}");
            return data;
        }
        public async Task<MainResponseModel> AttendanceDataCheckAsync(string date, int classid)
        {
            var data = await _httpClient.GetFromJsonAsync<MainResponseModel>($"api/Attendance/AttendanceDataCheck/{Uri.EscapeDataString(date)}/{classid}");
            return data;
        }

        public async Task<Result<LookUpSessions>> GetAttendanceSessionsAsync(int classid, int studentid, int quarterid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<LookUpSessions>>($"api/Attendance/GetAttendanceSessions/{classid}/{studentid}/{quarterid}");
            return data;
        }

        public async Task<Result<List<string>>> GetMonthsPerClassAsync(int classid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<string>>>($"api/Attendance/GetMonthsperClass/{classid}");
            return data;
        }
    }
}
