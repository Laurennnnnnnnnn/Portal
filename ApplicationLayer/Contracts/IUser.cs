using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contracts
{
    public interface IUser
    {
        Task<Result<User>> UserLogin(string username, string password);
        Task<ServiceResponse> AddUser(User userdata); //procAddUser
        Task<Result<List<User>>> GetAllVerifiedUser(); //procGetAllVerifiedUser
        Task<Result<List<User>>> GetAllUnverifiedUser(); //procGetAllUnverifiedUser
        Task<ServiceResponse> UpdateUser(User userdata); //procUpdateUser
        Task<ServiceResponse> VerifyUser(int userdataid, int userid); //procVerifyUser
        Task<ServiceResponse> UnverifyUser(int userdataid, int userid); //procVerifyUser
        Task<ServiceResponse> DeleteUser(int userdataid, int userid); //procDeleteUser
        Task<Result<List<UserType>>> GetUserType();
        Task<Result<List<Category>>> GetCategory();
    }
}
