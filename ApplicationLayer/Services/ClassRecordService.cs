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

namespace ApplicationLayer.Services
{
    public class ClassRecordService : IClassRecordService
    {
        private readonly HttpClient _httpClient;
        public ClassRecordService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RecordModel> GetAllStudentsRecordsAsync(int classid, int quarterid)
        {
            var data = await _httpClient.GetFromJsonAsync<RecordModel>($"api/Record/GetStudentsRecords/{classid}/{quarterid}");
            return data;
        }

        public async Task<Result<List<WrittenOutput>>> GetWrittenOutputAsync(int classid, int quarterid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<WrittenOutput>>>($"api/Record/GetWrittenOutput/{classid}/{quarterid}");
            return data;
        }

        public async Task<Result<List<Quarter>>> GetQuartersAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<Quarter>>>($"api/Resources/GetQuarters");
            return data;
        }

        public async Task<Result<List<PerformanceOutput>>> GetPerformanceOutputAsync(int classid, int quarterid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<PerformanceOutput>>>($"api/Record/GetPerformanceOutput/{classid}/{quarterid}");
            return data;
        }

        public async Task<Result<List<PeriodicalOutput>>> GetPeriodicalOutputAsync(int classid, int quarterid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<PeriodicalOutput>>>($"api/Record/GetPeriodicalOutput/{classid}/{quarterid}");
            return data;
        }

        public async Task<Result<WrittenData>> WrittenDataAddUpdateAsync(WrittenData writtenData, int userid)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Record/WrittenADU/{userid}", writtenData);
            var response = await data.Content.ReadFromJsonAsync<Result<WrittenData>>();
            return response!;
        }

        public async Task<Result<PerformanceData>> PerformanceDataAddUpdateAsync(PerformanceData performanceData, int userid)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Record/PerformanceADU/{userid}", performanceData);
            var response = await data.Content.ReadFromJsonAsync<Result<PerformanceData>>();
            return response!;
        }

        public async Task<Result<PeriodicalData>> PeriodicalDataAddUpdateAsync(PeriodicalData periodicalData, int userid)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Record/PeriodicalADU/{userid}", periodicalData);
            var response = await data.Content.ReadFromJsonAsync<Result<PeriodicalData>>();
            return response!;
        }

        public async Task<Result<int>> GetGradeRulesAsync(double initialgrade)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<int>>($"api/Record/GetGradeRules/{initialgrade}");
            return data;
        }

        public async Task<Result<List<RecordStudents>>> GetStudentAsync(int classid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<RecordStudents>>>($"api/Record/GetStudents/{classid}");
            return data;
        }

        public async Task<Result<WrittenData>> GetWrittenDataAsync(int studentid, int writtenoutputid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<WrittenData>>($"api/Record/GetWrittenData/{studentid}/{writtenoutputid}");
            return data;
        }

        public async Task<Result<PerformanceData>> GetPerformanceDataAsync(int studentid, int performanceoutputid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<PerformanceData>>($"api/Record/GetPerformanceData/{studentid}/{performanceoutputid}");
            return data;
        }

        public async Task<Result<PeriodicalData>> GetPeriodicalDataAsync(int studentid, int periodicaloutputid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<PeriodicalData>>($"api/Record/GetPeriodicalData/{studentid}/{periodicaloutputid}");
            return data;
        }

        public async Task<RecordModel> GetQuarterSummary(int classid)
        {
            var data = await _httpClient.GetFromJsonAsync<RecordModel>($"api/Record/GetSummaryQuarter/{classid}");
            return data;
        }

        public async Task<ServiceResponse> AddWrittenOutputAsync(WrittenOutput output, int userid)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Record/AddWrittenOutput/{userid}", output);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> AddPerformanceOutputAsync(PerformanceOutput output, int userid)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Record/AddPerformanceOutput/{userid}", output);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> AddPeriodicalOutputAsync(PeriodicalOutput output, int userid)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Record/AddPeriodicalOutput/{userid}", output);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> UpdateWrittenOutputAsync(WrittenOutput writtenOutput, int userid)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Record/UpdateWrittenOutput/{userid}", writtenOutput);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> UpdatePerformanceOutputAsync(PerformanceOutput performanceOutput, int userid)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Record/UpdatePerformanceOutput/{userid}", performanceOutput);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> UpdatePeriodicalOutputAsync(PeriodicalOutput periodicalOutput, int userid)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Record/UpdatePeriodicalOutput/{userid}", periodicalOutput);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteWrittenOutputAsync(int writtenoutputid, int userid)
        {
            var data = await _httpClient.DeleteFromJsonAsync<ServiceResponse>($"api/Record/DeleteWritten/{writtenoutputid}/{userid}");
            return data;
        }

        public async Task<ServiceResponse> DeletePerformanceOutputAsync(int performanceoutputid, int userid)
        {
            var data = await _httpClient.DeleteFromJsonAsync<ServiceResponse>($"api/Record/DeletePerformance/{performanceoutputid}/{userid}");
            return data;
        }

        public async Task<ServiceResponse> DeletePeriodicalOutputAsync(int periodicaloutputid, int userid)
        {
            var data = await _httpClient.DeleteFromJsonAsync<ServiceResponse>($"api/Record/DeletePeriodical/{periodicaloutputid}/{userid}");
            return data;
        }

        public async Task<RecordModel> GetStudentGradeComponents(int classid, int studentid)
        {
            var data = await _httpClient.GetFromJsonAsync<RecordModel>($"api/Record/GetStudentGrades/{classid}/{studentid}");
            return data;
        }

        public async Task<SummaryOutputs> GetStudentsClassSummaryAsync(int classid, int quarterid)
        {
            var data = await _httpClient.GetFromJsonAsync<SummaryOutputs>($"api/Record/GetStudentsClassSummary/{classid}/{quarterid}");
            return data;
        }

        public async Task<Dictionary<string, RecordQuarters>> GetSummaryQuarterByStudent(int classid, int studentid)
        {
            var data = await _httpClient.GetFromJsonAsync<Dictionary<string, RecordQuarters>>($"api/Record/GetSummaryQuarterByStudent/{classid}/{studentid}");
            return data;
        }
    }
}
