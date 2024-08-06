using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contracts
{
    public interface IStudent //FOR WITH CLASS ONLY
    {
        //COMPLEX RESPONSE: 
        Task<Result<List<Student>>> GetAllStudentsAsync(int classid); //GET STUDENT BY CLASSID
        Task<Result<Student?>> GetStudentFromClassByIdAsync(int studentid, int classid); //GET STUDENT BY ID

        //SINGLE RESPONSE 
        Task<ServiceResponse> AddStudentoClassAsync(int studentid, int classid, int userid);
        Task<ServiceResponse> UpdateStudentAsync(Student student, int userid);
        Task<ServiceResponse> DeleteStudentFromClassAsync(int studentid, int classid, int userid);
    }
}
