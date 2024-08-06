using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class ClassService : IClassService
    {
        private readonly HttpClient _httpClient;
        public ClassService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }

        public async Task<Result<Class>> AddClassAsync(Class classdata, int userid)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/Class/AddClass/{userid}", classdata);
            var response = await data.Content.ReadFromJsonAsync<Result<Class>>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteClassAsync(int classid, int userid)
        {
            var data = await _httpClient.DeleteAsync($"api/Class/DeleteClass/{classid}/{userid}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<Result<List<Class>>> GetAllClassListAsync(int userid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<Class>>>($"api/Class/GetAllClass/{userid}");
            return data;
        }

        public async Task<Result<List<Class>>> GetClassByUserSchoolYearAsync(int userid, int schooolyearid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<Class>>>($"api/Class/GetAllClass/{userid}/{schooolyearid}");
            return data;
        }

        public async Task<Result<Class>> GetClassListbyIDAsync(int classid)
        {
            var data = await _httpClient.GetFromJsonAsync<Result<Class>>($"api/Class/GetClassbyID/{classid}");
            return data;
        }

        public async Task<Result<Class>> UpdateClassAsync(Class classdata, int userid)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Class/UpdateClass/{userid}", classdata);
            var response = await data.Content.ReadFromJsonAsync<Result<Class>>();
            return response!;
        }
    }
}
