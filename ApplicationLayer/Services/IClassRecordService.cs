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
    public interface IClassRecordService
    {
        Task<RecordModel> GetAllStudentsRecordsAsync(int classid, int quarterid);
        Task<SummaryOutputs> GetStudentsClassSummaryAsync(int classid, int quarterid);
        Task<Result<List<WrittenOutput>>> GetWrittenOutputAsync(int classid, int quarterid);
        //get performance outputs
        Task<Result<List<PerformanceOutput>>> GetPerformanceOutputAsync(int classid, int quarterid);
        //get periodical outputs
        Task<Result<List<PeriodicalOutput>>> GetPeriodicalOutputAsync(int classid, int quarterid);
        Task<Result<List<Quarter>>> GetQuartersAsync();
        Task<Result<WrittenData>> WrittenDataAddUpdateAsync(WrittenData writtenData, int userid);
        //add/update performancedata
        Task<Result<PerformanceData>> PerformanceDataAddUpdateAsync(PerformanceData performanceData, int userid);
        //add/update periodicaldata
        Task<Result<PeriodicalData>> PeriodicalDataAddUpdateAsync(PeriodicalData periodicalData, int userid);
        Task<Result<int>> GetGradeRulesAsync(double initialgrade);
        Task<Result<List<RecordStudents>>> GetStudentAsync(int classid);
        Task<Result<WrittenData>> GetWrittenDataAsync(int studentid, int writtenoutputid);
        //get performance data per student
        Task<Result<PerformanceData>> GetPerformanceDataAsync(int studentid, int performanceoutputid);
        //get periodical data per student
        Task<Result<PeriodicalData>> GetPeriodicalDataAsync(int studentid, int periodicaloutputid);

        Task<RecordModel> GetQuarterSummary(int classid);
        Task<Dictionary<string, RecordQuarters>> GetSummaryQuarterByStudent(int classid, int studentid);
        Task<RecordModel> GetStudentGradeComponents(int classid, int studentid);

        Task<ServiceResponse> AddWrittenOutputAsync(WrittenOutput output, int userid);
        //add new performanceoutput
        Task<ServiceResponse> AddPerformanceOutputAsync(PerformanceOutput output, int userid);
        //add new periodicaloutput
        Task<ServiceResponse> AddPeriodicalOutputAsync(PeriodicalOutput output, int userid);
        Task<ServiceResponse> UpdateWrittenOutputAsync(WrittenOutput writtenOutput, int userid);
        //update performanceoutput
        Task<ServiceResponse> UpdatePerformanceOutputAsync(PerformanceOutput performanceOutput, int userid);
        //update periodicaloutput
        Task<ServiceResponse> UpdatePeriodicalOutputAsync(PeriodicalOutput periodicalOutput, int userid);

        //delete writtenouput
        Task<ServiceResponse> DeleteWrittenOutputAsync(int writtenoutputid, int userid);
        //delete performanceoutput
        Task<ServiceResponse> DeletePerformanceOutputAsync(int performanceoutputid, int userid);
        //delete periodicaloutput
        Task<ServiceResponse> DeletePeriodicalOutputAsync(int periodicaloutputid, int userid);


    }
}
