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
    public interface IUserService
    {
        Task<Result<User>> UserLogin(string username, string password);
        Task<ServiceResponse> AddUser(User userdata); 
        Task<Result<List<User>>> GetAllVerifiedUser(); 
        Task<Result<List<User>>> GetAllUnverifiedUser(); 
        Task<ServiceResponse> UpdateUser(User userdata); 
        Task<ServiceResponse> VerifyUser(int userdataid, int userid); 
        
        Task<ServiceResponse> UnverifyUser(int userdataid, int userid); 
        Task<ServiceResponse> DeleteUser(int userdataid, int userid);
        Task<Result<List<UserType>>> GetUserType();
        Task<Result<List<Category>>> GetCategory();
        //Task<Payroll> PostPayroll();
    }
}
