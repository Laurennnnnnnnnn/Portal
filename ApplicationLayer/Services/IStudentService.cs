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
    public interface IStudentService
    {
      
        Task<StudentsModel> GetAllStudentsAsync(int classid); //GET STUDENT BY CLASSID
        Task<StudentsModel> SearchStudentsAsync(Student student);
        Task<StudentModel> GetStudentFromClassByIdAsync(int studentid, int classid); //GET STUDENT BY ID
        Task<MainResponseModel> AddStudentoClassAsync(int studentid, int classid, int userid);
        Task<MainResponseModel> UpdateStudentAsync(Student student, int userid);
        Task<MainResponseModel> DeleteStudentFromClassAsync(int studentid, int classid, int userid);
        Task<MainResponseModel> AddStudentAfterClass(Student student, int userid, int classid);
        Task<MainResponseModel> AddNewStudent(Student student, int userid);
    }
}
