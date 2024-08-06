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
    public class UserRepository : IUser
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> AddUser(User userdata)
        {
            var procedureName = "procAddUser";
            var parameters = new DynamicParameters();
            parameters.Add("Username ", userdata.Username, DbType.String);
            parameters.Add("Fullname ", userdata.Fullname, DbType.String);
            parameters.Add("Password ", userdata.Password, DbType.String);
            parameters.Add("UserTypeID ", userdata.UserTypeID, DbType.Int32);
            parameters.Add("CategoryID ", userdata.CategoryID, DbType.Int32);
            parameters.Add("Designation ", userdata.Designation, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "Theres something wrong with the user information");
                return new ServiceResponse(true, "Added");
            }
        }

        public async Task<ServiceResponse> DeleteUser(int userdataid, int userid)
        {
            var procedureName = "procDeleteUser";
            var parameters = new DynamicParameters();
            parameters.Add("UserID ", userdataid, DbType.Int32);
            parameters.Add("DeleterID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "Theres something wrong with the user");
                return new ServiceResponse(true, "Deleted");
            }
        }

        public async Task<Result<List<User>>> GetAllUnverifiedUser()
        {
            var procedureName = "procGetAllUnverifiedUser";
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<User>(procedureName, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<User>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<User>>.Failure("No student records found for the provided criteria.");
                }
            }
        }
        public async Task<Result<List<User>>> GetAllVerifiedUser()
        {
            var procedureName = "procGetAllVerifiedUser";
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<User>(procedureName, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<User>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<User>>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<List<Category>>> GetCategory()
        {
            var procedureName = "procGetCategory";
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<Category>(procedureName, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<Category>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<Category>>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<Result<List<UserType>>> GetUserType()
        {
            var procedureName = "procGetUserType";
            using (var connection = _context.CreateConnection())
            {
                var studentData = await connection.QueryAsync<UserType>(procedureName, commandType: CommandType.StoredProcedure);
                if (studentData.Any())
                {
                    return Result<List<UserType>>.Success(studentData.ToList());
                }
                else
                {
                    return Result<List<UserType>>.Failure("No student records found for the provided criteria.");
                }
            }
        }

        public async Task<ServiceResponse> UpdateUser(User userdata)
        {
            var procedureName = "procUpdateUser";
            var parameters = new DynamicParameters();
            parameters.Add("UserID ", userdata.UserID, DbType.Int32);
            parameters.Add("Username ", userdata.Username, DbType.String);
            parameters.Add("Fullname ", userdata.Fullname, DbType.String);
            parameters.Add("Password ", userdata.Password, DbType.String);
            parameters.Add("UserTypeID ", userdata.UserTypeID, DbType.Int32);
            parameters.Add("CategoryID ", userdata.CategoryID, DbType.Int32);
            parameters.Add("Activate ", userdata.Activate, DbType.Boolean);
            parameters.Add("Designation ", userdata.Designation, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "Student not found");
                return new ServiceResponse(true, "Updated");
            }
        }

        public async Task<Result<User>> UserLogin(string username, string password)
        {
            var procedureName = "procLogin";
            var parameters = new DynamicParameters();
            parameters.Add("Username ", username, DbType.String);
            parameters.Add("Password ", password, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var userdata = await connection.QueryFirstOrDefaultAsync<User>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (userdata != null)
                {
                    return Result<User>.Success(userdata);
                }
                else
                {
                    return Result<User>.Failure("Incorrect Username or Password");
                }
            }
        }

        public async Task<ServiceResponse> VerifyUser(int userdataid, int userid)
        {
            var procedureName = "procVerifyUser";
            var parameters = new DynamicParameters();
            parameters.Add("UserID ", userdataid, DbType.Int32);
            parameters.Add("VerifierID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "Theres something wrong with the user");
                return new ServiceResponse(true, "Verified");
            }
        }

        public async Task<ServiceResponse> UnverifyUser(int userdataid, int userid)
        {
            var procedureName = "procUnverifyUser";
            var parameters = new DynamicParameters();
            parameters.Add("UserID ", userdataid, DbType.Int32);
            parameters.Add("UnverifierID ", userid, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var subjectdata = await connection.QueryFirstOrDefaultAsync<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!subjectdata) return new ServiceResponse(false, "Theres something wrong with the user");
                return new ServiceResponse(true, "Unverified");
            }
        }
    }
}
