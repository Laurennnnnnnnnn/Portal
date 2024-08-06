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
using static System.Collections.Specialized.BitVector32;

namespace InfrastructureLayer.Implementations
{
    public class ClassRepository : IClass
    {
        private readonly DapperContext _context;
        public ClassRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Result<Class>> AddClassAsync(Class classdata, int userid) //ADD CLASS THEN RETREIVE THE NEW ADDED CLASS
        {
            var procedureName = "procAddClass";
            var parameters = new DynamicParameters();
            parameters.Add("ClassName ", classdata.ClassName, DbType.String);
            parameters.Add("SubjectID ", classdata.SubjectID, DbType.Int32);
            parameters.Add("GradeID ", classdata.GradeID, DbType.Int32);
            parameters.Add("SectionID ", classdata.SectionID, DbType.Int32);
            parameters.Add("SchoolYearID ", classdata.SchoolYearID, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<Class>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data != null)
                {
                    return Result<Class>.Success(data);
                }
                else
                {
                    return Result<Class>.Failure("Adding Class Failed");
                }
            }
        }

        public async Task<ServiceResponse> DeleteClassAsync(int classid, int userid)
        {
            var procedureName = "procDeleteClass";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID", classid, DbType.Int32);
            parameters.Add("UserID", userid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!data) return new ServiceResponse(false, "Failed to Delete Class");
                return new ServiceResponse(true, "Deleted");
            }
        }

        public async Task<Result<List<Class>>> GetAllClassListAsync(int userid) //GET ALL CLASS CREATEDBY THE USER
        {
            var procedureName = "procGetClassbyUserID";
            var parameters = new DynamicParameters();
            parameters.Add("UserID ", userid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<Class>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data != null)
                {
                    return Result<List<Class>>.Success(data.ToList());
                }
                else
                {
                    return Result<List<Class>>.Failure("No class found.");
                }
            }
        }

        public async Task<Result<List<Class>>> GetClassByUserSchoolYearAsync(int userid, int schoolyearid) //GET ALL CLASS CREATEDBY THE USER
        {
            var procedureName = "procGetClassbySchoolYearUserID";
            var parameters = new DynamicParameters();
            parameters.Add("UserID ", userid, DbType.Int32);
            parameters.Add("SchoolYearID ", schoolyearid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<Class>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data != null)
                {
                    return Result<List<Class>>.Success(data.ToList());
                }
                else
                {
                    return Result<List<Class>>.Failure("No class found.");
                }
            }
        }

        public async Task<Result<Class>> GetClassListbyIDAsync(int classid) //GET CLASS WITH CLASS
        {
            var procedureName = "procGetClassInfobyID";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID ", classid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<Class>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data != null)
                {
                    return Result<Class>.Success(data);
                }
                else
                {
                    return Result<Class>.Failure("No class found.");
                }
            }
        }

        public async Task<Result<Class>> UpdateClassAsync(Class classdata, int userid)
        {
            var procedureName = "procUpdateClass";
            var parameters = new DynamicParameters();
            parameters.Add("ClassName ", classdata.ClassName, DbType.String);
            parameters.Add("SubjectID ", classdata.SubjectID, DbType.Int32);
            parameters.Add("GradeID ", classdata.GradeID, DbType.Int32);
            parameters.Add("SectionID ", classdata.SectionID, DbType.Int32);
            parameters.Add("SchoolYearID ", classdata.SchoolYearID, DbType.Int32);
            parameters.Add("UserID ", userid, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryFirstOrDefaultAsync<Class>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (data != null)
                {
                    return Result<Class>.Success(data);
                }
                else
                {
                    return Result<Class>.Failure("Updating Class Failed");
                }
            }
        }
    }
}
