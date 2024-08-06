using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contracts
{
    public interface IClass
    {
        //COMPLEX RESPONSE: 
        Task<Result<List<Class>>> GetAllClassListAsync(int userid);
        Task<Result<List<Class>>> GetClassByUserSchoolYearAsync(int userid, int schoolyearid);
        Task<Result<Class>> GetClassListbyIDAsync(int classid);

        //SINGLE RESPONSE 
        Task<Result<Class>> AddClassAsync(Class classdata, int userid);
        Task<Result<Class>> UpdateClassAsync(Class classdata, int userid);
        Task<ServiceResponse> DeleteClassAsync(int classid, int userid);
    }
}
