using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using Dapper;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Implementations
{
    public class RecordRepository : IRecord
    {
        private readonly DapperContext _context;
        private readonly IMemoryCache _cache;
        public RecordRepository(DapperContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<Result<List<RecordStudents>>> GetStudentAsync(int classid)
        {
            var procedureName = "procGetAllStudentbyClass";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID", classid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<RecordStudents>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<RecordStudents>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<RecordStudents>>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<List<WrittenOutput>>> GetWrittenOutputAsync(int classid, int quarterid)
        {
            var procedureName = "procGetWrittenTaskRecord";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID", classid, DbType.Int32);
            parameters.Add("QuarterID", quarterid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<WrittenOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<WrittenOutput>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<WrittenOutput>>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<List<PerformanceOutput>>> GetPerformanceOutputAsync(int classid, int quarterid)
        {
            var procedureName = "procGetPerformTaskRecord";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID", classid, DbType.Int32);
            parameters.Add("QuarterID", quarterid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<PerformanceOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<PerformanceOutput>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<PerformanceOutput>>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<List<PeriodicalOutput>>> GetPeriodicalOutputAsync(int classid, int quarterid)
        {
            var procedureName = "procGetPeriodicalTaskRecord";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID", classid, DbType.Int32);
            parameters.Add("QuarterID", quarterid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<PeriodicalOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<PeriodicalOutput>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<PeriodicalOutput>>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<WrittenData>> GetWrittenDataAsync(int studentid, int writtenoutputid)
        {
            var procedureName = "procGetWrittenTaskData";
            var parameters = new DynamicParameters();
            parameters.Add("StudentID", studentid, DbType.Int32);
            parameters.Add("WrittenOutputID", writtenoutputid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryFirstOrDefaultAsync<WrittenData>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData != null)
                {
                    return Result<WrittenData>.Success(studentData);
                }
                else
                {
                    return Result<WrittenData>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<PerformanceData>> GetPerformanceDataAsync(int studentid, int performanceoutputid)
        {
            var procedureName = "procGetPerformTaskData";
            var parameters = new DynamicParameters();
            parameters.Add("StudentID", studentid, DbType.Int32);
            parameters.Add("PerformanceOutputID", performanceoutputid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryFirstOrDefaultAsync<PerformanceData>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData != null)
                {
                    return Result<PerformanceData>.Success(studentData);
                }
                else
                {
                    return Result<PerformanceData>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<PeriodicalData>> GetPeriodicalDataAsync(int studentid, int periodicaloutputid)
        {
            var procedureName = "procGetPeriodicalTaskData";
            var parameters = new DynamicParameters();
            parameters.Add("StudentID", studentid, DbType.Int32);
            parameters.Add("PeriodicalOutputID", periodicaloutputid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryFirstOrDefaultAsync<PeriodicalData>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData != null)
                {
                    return Result<PeriodicalData>.Success(studentData);
                }
                else
                {
                    return Result<PeriodicalData>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<ServiceResponse> AddWrittenOutputAsync(WrittenOutput output, int userid)
        {
            var procedureName = "procAddWrittenTask";
            var parameters = new DynamicParameters();
            parameters.Add("WrittenOutputName ", output.WrittenOutputName, DbType.String);
            parameters.Add("ClassID ", output.ClassID, DbType.Int32);
            parameters.Add("QuarterID ", output.QuarterID, DbType.Int32);
            parameters.Add("MaxScore ", output.MaxScore, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<WrittenOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (subjectdata == null) return new ServiceResponse(false, "Add Record Failed");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<ServiceResponse> AddPerformanceOutputAsync(PerformanceOutput output, int userid)
        {
            var procedureName = "procAddPerformanceTask";
            var parameters = new DynamicParameters();
            parameters.Add("PerformanceOutputName ", output.PerformanceOutputName, DbType.String);
            parameters.Add("ClassID ", output.ClassID, DbType.Int32);
            parameters.Add("QuarterID ", output.QuarterID, DbType.Int32);
            parameters.Add("MaxScore ", output.MaxScore, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<PerformanceOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (subjectdata == null) return new ServiceResponse(false, "Add Record Failed");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<ServiceResponse> AddPeriodicalOutputAsync(PeriodicalOutput output, int userid)
        {
            var procedureName = "procAddPeriodicalTask";
            var parameters = new DynamicParameters();
            parameters.Add("PeriodicalOutputName ", output.PeriodicalOutputName, DbType.String);
            parameters.Add("ClassID ", output.ClassID, DbType.Int32);
            parameters.Add("QuarterID ", output.QuarterID, DbType.Int32);
            parameters.Add("MaxScore ", output.MaxScore, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<PeriodicalOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (subjectdata == null) return new ServiceResponse(false, "Add Record Failed");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<ServiceResponse> UpdateWrittenOutputAsync(WrittenOutput writtenOutput, int userid)
        {
            var procedureName = "procEditWrittenTask";
            var parameters = new DynamicParameters();
            parameters.Add("WrittenOutputID ", writtenOutput.WrittenOutputID, DbType.Int32);
            parameters.Add("WrittenOutputName ", writtenOutput.WrittenOutputName, DbType.String);
            parameters.Add("ClassID ", writtenOutput.ClassID, DbType.Int32);
            parameters.Add("QuarterID ", writtenOutput.QuarterID, DbType.Int32);
            parameters.Add("MaxScore ", writtenOutput.MaxScore, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "No Record found");
                return new ServiceResponse(true, "Updated");
            }
        }
        public async Task<ServiceResponse> UpdatePerformanceOutputAsync(PerformanceOutput performanceOutput, int userid)
        {
            var procedureName = "procEditPerformanceTask";
            var parameters = new DynamicParameters();
            parameters.Add("PerformanceOutputID ", performanceOutput.PerformanceOutputID, DbType.Int32);
            parameters.Add("PerformanceOutputName ", performanceOutput.PerformanceOutputName, DbType.String);
            parameters.Add("ClassID ", performanceOutput.ClassID, DbType.Int32);
            parameters.Add("QuarterID ", performanceOutput.QuarterID, DbType.Int32);
            parameters.Add("MaxScore ", performanceOutput.MaxScore, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "No Record found");
                return new ServiceResponse(true, "Updated");
            }
        }

        public async Task<ServiceResponse> UpdatePeriodicalOutputAsync(PeriodicalOutput periodicalOutput, int userid)
        {
            var procedureName = "procEditPeriodicalTask";
            var parameters = new DynamicParameters();
            parameters.Add("PeriodicalOutputID ", periodicalOutput.PeriodicalOutputID, DbType.Int32);
            parameters.Add("PeriodicalOutputName ", periodicalOutput.PeriodicalOutputName, DbType.String);
            parameters.Add("ClassID ", periodicalOutput.ClassID, DbType.Int32);
            parameters.Add("QuarterID ", periodicalOutput.QuarterID, DbType.Int32);
            parameters.Add("MaxScore ", periodicalOutput.MaxScore, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "No Record found");
                return new ServiceResponse(true, "Updated");
            }
        }

        public async Task<ServiceResponse> DeleteWrittenOutputAsync(int writtenoutputid, int userid)
        {
            var procedureName = "procDeleteWrittenTask";
            var parameters = new DynamicParameters();
            parameters.Add("WrittenOutputID ", writtenoutputid, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "No Record found");
                return new ServiceResponse(true, "Deleted");
            }
        }
        public async Task<ServiceResponse> DeletePerformanceOutputAsync(int performanceoutputid, int userid)
        {
            var procedureName = "procDeletePerformanceTask";
            var parameters = new DynamicParameters();
            parameters.Add("PerformanceOutputID ", performanceoutputid, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "No Record found");
                return new ServiceResponse(true, "Deleted");
            }
        }

        public async Task<ServiceResponse> DeletePeriodicalOutputAsync(int periodicaloutputid, int userid)
        {
            var procedureName = "procDeletePeriodicalTask";
            var parameters = new DynamicParameters();
            parameters.Add("PeriodicalOutputID ", periodicaloutputid, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "No Record found");
                return new ServiceResponse(true, "Deleted");
            }
        }
        public async Task<Result<WrittenData>> WrittenDataAddUpdateAsync(WrittenData writtenData, int userid)
        {
            var procedureName = "procAdUpWrittenData";
            var parameters = new DynamicParameters();
            parameters.Add("WrittenDataID ", writtenData.WrittenDataID, DbType.Int32);
            parameters.Add("StudentID ", writtenData.StudentID, DbType.Int32);
            parameters.Add("WrittenOutputID ", writtenData.WrittenOutputID, DbType.Int32);
            parameters.Add("Score ", writtenData.Score, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<WrittenData>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (subjectdata != null)
                {
                    return Result<WrittenData>.Success(subjectdata);
                }
                else
                {
                    return Result<WrittenData>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<PerformanceData>> PerformanceDataAddUpdateAsync(PerformanceData performanceData, int userid)
        {
            var procedureName = "procAdUpPerformanceData";
            var parameters = new DynamicParameters();
            parameters.Add("PerformanceDataID ", performanceData.PerformanceDataID, DbType.Int32);
            parameters.Add("StudentID ", performanceData.StudentID, DbType.Int32);
            parameters.Add("PerformanceOutputID ", performanceData.PerformanceOutputID, DbType.Int32);
            parameters.Add("Score ", performanceData.Score, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<PerformanceData>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (subjectdata != null)
                {
                    return Result<PerformanceData>.Success(subjectdata);
                }
                else
                {
                    return Result<PerformanceData>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<PeriodicalData>> PeriodicalDataAddUpdateAsync(PeriodicalData periodicalData, int userid)
        {
            var procedureName = "procAdUpPeriodicalData";
            var parameters = new DynamicParameters();
            parameters.Add("PeriodicalDataID ", periodicalData.PeriodicalDataID, DbType.Int32);
            parameters.Add("StudentID ", periodicalData.StudentID, DbType.Int32);
            parameters.Add("PeriodicalOutputID ", periodicalData.PeriodicalOutputID, DbType.Int32);
            parameters.Add("Score ", periodicalData.Score, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<PeriodicalData>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (subjectdata != null)
                {
                    return Result<PeriodicalData>.Success(subjectdata);
                }
                else
                {
                    return Result<PeriodicalData>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<int>> GetGradeRulesAsync(double initialgrade)
        {
            var procedureName = "procGetGradeRules";
            var parameters = new DynamicParameters();
            parameters.Add("InitialGrade", initialgrade, DbType.Double);
            using (var connection = _context.CreateConnection())
            {
                var grade = await connection.QueryFirstOrDefaultAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (grade != 0)
                {
                    return Result<int>.Success(grade);
                }
                else
                {
                    return Result<int>.Failure("No grade record found");
                }
            }
        }

        public async Task<Result<List<RecordStudents>>> GetStudentFromClassAsync(int classid, int studentid)
        {
            var procedureName = "procGetStudentsbyId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID ", classid, DbType.Int32);
            parameters.Add("StudentID ", studentid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<RecordStudents>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<RecordStudents>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<RecordStudents>>.Failure("Failed to retrieve student data.");
                }
            }
        }
    }
}
