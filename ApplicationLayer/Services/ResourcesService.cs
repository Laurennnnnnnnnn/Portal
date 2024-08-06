using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ApplicationLayer.Services
{
    public class ResourcesService : IResourcesService
    {
        private readonly HttpClient _httpClient;
        public ResourcesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddSchoolYearAsync(string schoolyearname)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Resources/AddSchoolYear/{schoolyearname}", new StringContent(""));
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> AddSectionAsync(string sectionname)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Resources/AddSection/{sectionname}", new StringContent(""));
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> AddSubjectAsync(string subjectname)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Resources/AddSubject/{subjectname}", new StringContent(""));
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
        public async Task<Result<List<GradeLevel>>> GetGradeAsync(int userlevel)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<GradeLevel>>>($"api/Resources/GetGrades/{userlevel}");
            return data;
        }

        public async Task<Result<List<Quarter>>> GetQuartersAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<Quarter>>>($"api/Resources/GetQuarters");
            return data;
        }

        public async Task<Result<List<SchoolYear>>> GetSchoolYearAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<SchoolYear>>>($"api/Resources/GetSchoolYear");
            return data;
        }

        public async Task<Result<List<Section>>> GetSectionAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<Section>>>($"api/Resources/GetSection");
            return data;
        }

        public async Task<Result<List<Subject>>> GetSubjectAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<Subject>>>($"api/Resources/GetSubject");
            return data;
        }

        public async Task<Result<List<WeightedScore>>> GetWeightedScoreAsync(int classid, int schoolyearid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<WeightedScore>>>($"api/Resources/GetWeightedScore/{classid}/{schoolyearid}");
            return data;
        }
        public async Task<Result<List<Outputs>>> GetOutputsAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<Outputs>>>($"api/Resources/GetOutputs");
            return data;
        }

        public async Task<ServiceResponse> UpdateSchoolYearAsync(SchoolYear schoolYear)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Resources/UpdateSchoolYear", schoolYear);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> UpdateSectionAsync(Section section)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Resources/UpdateSection", section);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> UpdateSubjectAsync(Subject subject)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Resources/UpdateSubject", subject);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteSchoolYearAsync(int schoolYearid, int userid)
        {
            var data = await _httpClient.DeleteAsync($"api/Resources/DeleteSchoolYear/{schoolYearid}/{userid}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteSectionAsync(int sectionid, int userid)
        {
            var data = await _httpClient.DeleteAsync($"api/Resources/DeleteSection/{sectionid}/{userid}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteSubjectAsync(int subjectid, int userid)
        {
            var data = await _httpClient.DeleteAsync($"api/Resources/DeleteSubject/{subjectid}/{userid}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> AddWeightedAsync(WeightedScore score)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Resources/AddWeighted", score);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> UpdateWeightedAsync(WeightedScore score)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Resources/UpdateWeighted", score);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteWeightedAsync(int weightedscoreid, int userid)
        {
            var data = await _httpClient.DeleteAsync($"api/Resources/DeleteWeighted/{weightedscoreid}/{userid}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<Result<List<QuartersDate>>> GetQuartersDateAsync(int schoolyearid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<QuartersDate>>>($"api/Resources/GetQuartersDate/{schoolyearid}");
            return data;
        }

        public async Task<ServiceResponse> AddQuartersDateAsync(QuartersDate date)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Resources/AddQuartersDate", date);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> UpdateQuartersDateAsync(QuartersDate date)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Resources/UpdateQuartersDate", date);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteQuartersDateAsync(int quartersdateid, int userid)
        {
            var data = await _httpClient.DeleteAsync($"api/Resources/DeleteQuartersDate/{quartersdateid}/{userid}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}
