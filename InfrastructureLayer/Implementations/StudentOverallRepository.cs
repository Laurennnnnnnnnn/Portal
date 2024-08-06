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

namespace InfrastructureLayer.Implementations
{
    public class StudentOverallRepository : IStudentOverall
    {
        private readonly DapperContext _context;
        public StudentOverallRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse> AddStudentAsync(Student student, int userid)
        {
            var procedureName = "procAddStudent";
            var parameters = new DynamicParameters();
            parameters.Add("Lastname ", student.Lastname, DbType.String);
            parameters.Add("Firstname ", student.Firstname, DbType.String);
            parameters.Add("Middlename ", student.Middlename, DbType.String);
            parameters.Add("Gender ", student.Gender, DbType.String);
            parameters.Add("Birthdate ", student.Birthdate, DbType.Date);
            parameters.Add("LRN ", student.LRN, DbType.String);
            parameters.Add("CreatorID ", 2, DbType.Int32);
            parameters.Add("Remarks ", student.Remarks, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<Student>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (subjectdata == null) return new ServiceResponse(false, "Failed to add new stundent");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<ServiceResponse> AddStudentAfterClassAsync(Student student, int userid, int classid)
        {
            var procedureName = "procAddStudentThentoClass";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID ", classid, DbType.Int32);
            parameters.Add("Lastname ", student.Lastname, DbType.String);
            parameters.Add("Firstname ", student.Firstname, DbType.String);
            parameters.Add("Middlename ", student.Middlename, DbType.String);
            parameters.Add("Gender ", student.Gender, DbType.String);
            parameters.Add("Birthdate ", student.Birthdate, DbType.Date);
            parameters.Add("LRN ", student.LRN, DbType.String);
            parameters.Add("CreatorID ", userid, DbType.Int32);
            parameters.Add("Remarks ", student.Remarks, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<Student>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (subjectdata == null) return new ServiceResponse(false, "Failed to add new stundent");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<Result<List<Student>>> SearchStudentAsync(Student student)
        {
            var procedureName = "procGetSearchStudent";
            var parameters = new DynamicParameters();
            parameters.Add("Lastname", !string.IsNullOrWhiteSpace(student.Lastname) ? student.Lastname : null, DbType.String);
            parameters.Add("Firstname", !string.IsNullOrWhiteSpace(student.Firstname) ? student.Firstname : null, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<Student>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<Student>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<Student>>.Failure("No student records found for the provided criteria.");
                }

            }
        }

        public async Task<Result<Student>> GetStudentDetails(int studentid)
        {
            var procedureName = "procGetStudentsbyId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassID ", 0, DbType.Int32);
            parameters.Add("StudentID ", studentid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryFirstOrDefaultAsync<Student>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                if (studentData != null)
                {
                    return Result<Student>.Success(studentData);
                }
                else
                {
                    return Result<Student>.Failure("Failed to retrieve student data.");
                }

            }
        }

        public async Task<ServiceResponse> UpdateStudentAsync(Student student, int userid)
        {
            var procedureName = "procUpdateStudentbyId";
            var parameters = new DynamicParameters();
            parameters.Add("StudentID ", student.StudentID, DbType.Int32);
            parameters.Add("Lastname ", student.Lastname, DbType.String);
            parameters.Add("Firstname ", student.Firstname, DbType.String);
            parameters.Add("Middlename ", student.Middlename, DbType.String);
            parameters.Add("Gender ", student.Gender, DbType.String);
            parameters.Add("Birthdate ", student.Birthdate, DbType.Date);
            parameters.Add("LRN ", student.LRN, DbType.String);
            parameters.Add("CreatorID ", 2, DbType.Int32);
            parameters.Add("Remarks ", student.Remarks, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "Student not found");
                return new ServiceResponse(true, "Updated");
            }
        }
        public async Task<ServiceResponse> DeleteStudentAsync(int studentid, int userid)
        {
            var procedureName = "procDeleteStudentbyId";
            var parameters = new DynamicParameters();
            parameters.Add("StudentID ", studentid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "Student not found");
                return new ServiceResponse(true, "Deleted");
            }
        }
    }
}
