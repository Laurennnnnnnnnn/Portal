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
using static System.Formats.Asn1.AsnWriter;

namespace InfrastructureLayer.Implementations
{
    public class ResourcesRepository : IResources
    {
        private readonly DapperContext _context;
        public ResourcesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> AddSchoolYearAsync(string schoolyearname)
        {
            var procedureName = "procAddSchoolYear";
            var parameters = new DynamicParameters();
            parameters.Add("SchoolYearName ", schoolyearname, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<SchoolYear>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data == null) return new ServiceResponse(false, "Failed to Add School Year");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<ServiceResponse> AddSectionAsync(string sectionname)
        {
            var procedureName = "procAddSection";
            var parameters = new DynamicParameters();
            parameters.Add("SectionName ", sectionname, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<Section>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data == null) return new ServiceResponse(false, "Failed to Add Section");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<ServiceResponse> AddSubjectAsync(string subjectname)
        {
            var procedureName = "procAddSubject";
            var parameters = new DynamicParameters();
            parameters.Add("SubjectName ", subjectname, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<Subject>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data == null) return new ServiceResponse(false, "Failed to Add Subject");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<Result<List<GradeLevel>>> GetGradeAsync(int userlevel)
        {
            var procedureName = "procGetGrades";

            var parameters = new DynamicParameters();
            parameters.Add("UserLevel ", userlevel, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<GradeLevel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data.Any())
                {
                    return Result<List<GradeLevel>>.Success(data.ToList());
                }
                else
                {
                    return Result<List<GradeLevel>>.Failure("No grade resources found.");
                }
            }
        }

        public async Task<Result<List<Quarter>>> GetQuartersAsync()
        {
            var procedureName = "procGetQuarters";
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<Quarter>(procedureName, commandType: CommandType.StoredProcedure);
                if (data.Any())
                {
                    return Result<List<Quarter>>.Success(data.ToList());
                }
                else
                {
                    return Result<List<Quarter>>.Failure("No quarter resources found.");
                }
            }
        }

        public async Task<Result<List<SchoolYear>>> GetSchoolYearAsync()
        {
            var procedureName = "procGetSchoolYears";
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<SchoolYear>(procedureName, commandType: CommandType.StoredProcedure);
                if (data.Any())
                {
                    return Result<List<SchoolYear>>.Success(data.ToList());
                }
                else
                {
                    return Result<List<SchoolYear>>.Failure("No SchoolYear resources found.");
                }
            }
        }

        public async Task<Result<List<Section>>> GetSectionAsync()
        {
            var procedureName = "procGetSections";
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<Section>(procedureName, commandType: CommandType.StoredProcedure);
                if (data.Any())
                {
                    return Result<List<Section>>.Success(data.ToList());
                }
                else
                {
                    return Result<List<Section>>.Failure("No Section resources found.");
                }
            }
        }

        public async Task<Result<List<Subject>>> GetSubjectAsync()
        {
            var procedureName = "procGetSubjects";
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<Subject>(procedureName, commandType: CommandType.StoredProcedure);
                if (data.Any())
                {
                    return Result<List<Subject>>.Success(data.ToList());
                }
                else
                {
                    return Result<List<Subject>>.Failure("No Section resources found.");
                }
            }
        }

        public async Task<ServiceResponse> UpdateSchoolYearAsync(SchoolYear schoolYear)
        {
            var procedureName = "procUpdateSchoolYear";
            var parameters = new DynamicParameters();
            parameters.Add("SchoolYearID", schoolYear.SchoolYearID, DbType.Int32);
            parameters.Add("SchoolYearName", schoolYear.SchoolYearName, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<SchoolYear>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data == null) return new ServiceResponse(false, "Failed to Update School Year");
                return new ServiceResponse(true, "Updated");
            }
        }

        public async Task<ServiceResponse> UpdateSectionAsync(Section section)
        {
            var procedureName = "procUpdateSection";
            var parameters = new DynamicParameters();
            parameters.Add("SectionID", section.SectionID, DbType.Int32);
            parameters.Add("SectionName", section.SectionName, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<Section>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data == null) return new ServiceResponse(false, "Failed to Update Section");
                return new ServiceResponse(true, "Updated");
            }
        }

        public async Task<ServiceResponse> UpdateSubjectAsync(Subject subject)
        {
            var procedureName = "procUpdateSubject";
            var parameters = new DynamicParameters();
            parameters.Add("SubjectID", subject.SubjectID, DbType.Int32);
            parameters.Add("SubjectName", subject.SubjectName, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<Subject>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data == null) return new ServiceResponse(false, "Failed to Update Subject");
                return new ServiceResponse(true, "Updated");
            }
        }

        public async Task<ServiceResponse> DeleteSchoolYearAsync(int schoolYearid, int userid)
        {
            var procedureName = "procDeleteSchoolYear";
            var parameters = new DynamicParameters();
            parameters.Add("SchoolYearID", schoolYearid, DbType.Int32);
            parameters.Add("UserID", userid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!data) return new ServiceResponse(false, "Failed to Delete SchoolYear");
                return new ServiceResponse(true, "Deleted");
            }
        }

        public async Task<ServiceResponse> DeleteSectionAsync(int sectionid, int userid)
        {
            var procedureName = "procDeleteSection";
            var parameters = new DynamicParameters();
            parameters.Add("SectionID", sectionid, DbType.Int32);
            parameters.Add("UserID", userid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!data) return new ServiceResponse(false, "Failed to Delete Section");
                return new ServiceResponse(true, "Deleted");
            }
        }

        public async Task<ServiceResponse> DeleteSubjectAsync(int subjectid, int userid)
        {
            var procedureName = "procDeleteSection";
            var parameters = new DynamicParameters();
            parameters.Add("SubjectID", subjectid, DbType.Int32);
            parameters.Add("UserID", userid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!data) return new ServiceResponse(false, "Failed to Delete Subject");
                return new ServiceResponse(true, "Deleted");
            }
        }

        public async Task<Result<List<WeightedScore>>> GetWeightedScoreAsync(int classid, int schoolyearid)
        {
            var procedureName = "procGetWeightedScores";

            var parameters = new DynamicParameters();
            parameters.Add("ClassID ", classid, DbType.Int32);
            parameters.Add("SchoolYearID ", schoolyearid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<WeightedScore>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data.Any())
                {
                    return Result<List<WeightedScore>>.Success(data.ToList());
                }
                else
                {
                    return Result<List<WeightedScore>>.Failure("No resources found.");
                }
            }
        }
        public async Task<Result<List<Outputs>>> GetOutputsAsync()
        {
            var procedureName = "procGetOutputs";
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<Outputs>(procedureName, commandType: CommandType.StoredProcedure);
                if (data.Any())
                {
                    return Result<List<Outputs>>.Success(data.ToList());
                }
                else
                {
                    return Result<List<Outputs>>.Failure("No outputs found.");
                }
            }
        }

        public async Task<ServiceResponse> AddWeightedAsync(WeightedScore score)
        {
            var procedureName = "procAddWeightedScore";
            var parameters = new DynamicParameters();
            parameters.Add("SchoolYearID", score.SchoolYearID, DbType.Int32);
            parameters.Add("QuarterID", score.QuarterID, DbType.Int32);
            parameters.Add("ClassID", score.ClassID, DbType.Int32);
            parameters.Add("Score", score.Score, DbType.Double);
            parameters.Add("OutputID", score.OutputID, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!data) return new ServiceResponse(false, "Failed to Add Weighted Score");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<ServiceResponse> UpdateWeightedAsync(WeightedScore score)
        {
            var procedureName = "procUpdateWeightedScore";
            var parameters = new DynamicParameters();
            parameters.Add("WeightedScoreID", score.WeightedScoreID, DbType.Int32);
            parameters.Add("Score", score.Score, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!data) return new ServiceResponse(false, "Failed to Updated Weighted Score");
                return new ServiceResponse(true, "Updated");
            }
        }

        public async Task<ServiceResponse> DeleteWeightedAsync(int weightedscoreid, int userid)
        {
            var procedureName = "procDeleteSection";
            var parameters = new DynamicParameters();
            parameters.Add("WeightedScoreID", weightedscoreid, DbType.Int32);
            parameters.Add("UserID", userid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!data) return new ServiceResponse(false, "Failed to Delete Weighted Score");
                return new ServiceResponse(true, "Deleted");
            }
        }

        public async Task<Result<List<QuartersDate>>> GetQuartersDateAsync(int schoolyearid)
        {
            var procedureName = "procGetQuartersDate";
            var parameters = new DynamicParameters();
            parameters.Add("SchoolYearID", schoolyearid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<QuartersDate>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data.Any())
                {
                    return Result<List<QuartersDate>>.Success(data.ToList());
                }
                else
                {
                    return Result<List<QuartersDate>>.Failure("No record found.");
                }
            }
        }

        public async Task<ServiceResponse> AddQuartersDateAsync(QuartersDate date)
        {
            var procedureName = "procAddQuartersDate";
            var parameters = new DynamicParameters();
            parameters.Add("DateFrom", DateTime.ParseExact(HttpUtility.UrlDecode(date.DateFrom), "MM/dd/yyyy", null), DbType.DateTime);
            parameters.Add("DateTo", DateTime.ParseExact(HttpUtility.UrlDecode(date.DateTo), "MM/dd/yyyy", null), DbType.DateTime);
            parameters.Add("SchoolYearID", date.SchoolYearID, DbType.Int32);
            parameters.Add("QuarterID", date.QuarterID, DbType.Int32);


            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!data) return new ServiceResponse(false, "Failed to Add Quarters Date");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<ServiceResponse> UpdateQuartersDateAsync(QuartersDate date)
        {
            var procedureName = "procUpdateQuartersDate";
            var parameters = new DynamicParameters();
            parameters.Add("QuartersDateID", date.QuartersDateID, DbType.Int32);
            parameters.Add("DateFrom", DateTime.ParseExact(HttpUtility.UrlDecode(date.DateFrom), "MM/dd/yyyy", null), DbType.DateTime);
            parameters.Add("DateTo", DateTime.ParseExact(HttpUtility.UrlDecode(date.DateTo), "MM/dd/yyyy", null), DbType.DateTime);
            parameters.Add("SchoolYearID", date.SchoolYearID, DbType.Int32);
            parameters.Add("QuarterID", date.QuarterID, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!data) return new ServiceResponse(false, "Failed to Updated Quarter Date");
                return new ServiceResponse(true, "Updated");
            }
        }

        public async Task<ServiceResponse> DeleteQuartersDateAsync(int quartersdateid, int userid)
        {
            var procedureName = "procDeleteQuartersDate";
            var parameters = new DynamicParameters();
            parameters.Add("QuartersDateID", quartersdateid, DbType.Int32);
            parameters.Add("UserID", userid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!data) return new ServiceResponse(false, "Failed to Delete Quarter Date");
                return new ServiceResponse(true, "Deleted");
            }
        }
    }
}
