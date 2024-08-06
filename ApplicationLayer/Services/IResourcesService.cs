using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IResourcesService
    {
        Task<Result<List<SchoolYear>>> GetSchoolYearAsync();
        Task<Result<List<Section>>> GetSectionAsync();
        Task<Result<List<Subject>>> GetSubjectAsync();
        Task<Result<List<QuartersDate>>> GetQuartersDateAsync(int schoolyearid);
        Task<Result<List<GradeLevel>>> GetGradeAsync(int userlevel);
        Task<Result<List<Quarter>>> GetQuartersAsync();
        Task<Result<List<WeightedScore>>> GetWeightedScoreAsync(int classid, int schoolyearid);
        Task<Result<List<Outputs>>> GetOutputsAsync();

        //SINGLE RESPONSE 
        Task<ServiceResponse> AddSchoolYearAsync(string schoolyearname);
        Task<ServiceResponse> AddSectionAsync(string sectionname);
        Task<ServiceResponse> AddSubjectAsync(string subjectname);
        Task<ServiceResponse> AddWeightedAsync(WeightedScore score);
        Task<ServiceResponse> AddQuartersDateAsync(QuartersDate date);

        Task<ServiceResponse> UpdateSchoolYearAsync(SchoolYear schoolYear);
        Task<ServiceResponse> UpdateSectionAsync(Section section);
        Task<ServiceResponse> UpdateSubjectAsync(Subject subject);
        Task<ServiceResponse> UpdateWeightedAsync(WeightedScore score);
        Task<ServiceResponse> UpdateQuartersDateAsync(QuartersDate date);

        Task<ServiceResponse> DeleteSchoolYearAsync(int schoolYearid, int userid);
        Task<ServiceResponse> DeleteSectionAsync(int sectionid, int userid);
        Task<ServiceResponse> DeleteSubjectAsync(int subjectid, int userid);
        Task<ServiceResponse> DeleteWeightedAsync(int weightedscoreid, int userid);
        Task<ServiceResponse> DeleteQuartersDateAsync(int quartersdateid, int userid);
    }
}
