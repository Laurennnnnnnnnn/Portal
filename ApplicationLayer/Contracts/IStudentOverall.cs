using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contracts
{
    public interface IStudentOverall //FOR OVERALL ONLY PROHIBITED STUDENT WITH CLASS
    {
        
        //COMPLEX RESPONSE: 
        Task<Result<List<Student>>> SearchStudentAsync(Student student);
        Task<Result<Student>> GetStudentDetails(int studentid);

        //SINGLE RESPONSE 
        Task<ServiceResponse> AddStudentAfterClassAsync(Student student, int userid, int classid); //SPECIAL FUNCTION: ADD STUDENT TO THE CLASS AFTER ADDING IT TO THE DATABASE
        Task<ServiceResponse> AddStudentAsync(Student student, int userid);
        Task<ServiceResponse> UpdateStudentAsync(Student student, int userid);
        Task<ServiceResponse> DeleteStudentAsync(int studentid, int userid);
    }

}
