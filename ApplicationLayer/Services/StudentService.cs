using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using JsonException = System.Text.Json.JsonException;
using DomainLayer.Models;

namespace ApplicationLayer.Services
{
    public class StudentService : IStudentService
    {
        
        
        private readonly HttpClient _httpClient;
        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<MainResponseModel> AddStudentoClassAsync(int studentid, int classid, int userid)
        {
            
            var data = await _httpClient.PostAsJsonAsync($"api/Student/class/{classid}/student/{studentid}/user/{userid}", new StringContent(""));
            var response = await data.Content.ReadFromJsonAsync<MainResponseModel>();
            return response!;
        }

        public async Task<MainResponseModel> DeleteStudentFromClassAsync(int studentid, int classid, int userid)
        {
            var data = await _httpClient.DeleteAsync($"api/Student/class/{classid}/student/{studentid}/user/{userid}");

            if (!data.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to delete student from class. Status code: {data.StatusCode}");
            }

            var responseContent = await data.Content.ReadAsStringAsync();
            Console.WriteLine("Response Content Before Deserialization: " + responseContent); // Debug

            try
            {
                var serviceResponse = JsonSerializer.Deserialize<MainResponseModel>(responseContent);

                if (serviceResponse != null)
                {
                    return serviceResponse;
                }
                else
                {
                    throw new JsonException("Failed to deserialize response.");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error During Deserialization: " + ex.Message); // Debug
                throw new JsonException("Failed to deserialize JSON response.", ex);
            }
        } 
        public async Task<StudentsModel> GetAllStudentsAsync(int classid)
        {
            var data = await _httpClient.GetFromJsonAsync<StudentsModel>($"api/Student/GetStudents/{classid}");
            return data;
        }
        public async Task<StudentModel> GetStudentFromClassByIdAsync(int studentid, int classid)
        {
            var data = await _httpClient.GetFromJsonAsync<StudentModel>($"api/Student/{classid}/{studentid}");
            return data;
        }

        public async Task<StudentsModel> SearchStudentsAsync(Student student)
        {
            //var data = await _httpClient.GetFromJsonAsync<StudentsModel>($"api/StudentOverall/SearchStudent", as);
            var data = await _httpClient.PostAsJsonAsync($"api/StudentOverall/SearchStudent", student);
            var response = await data.Content.ReadFromJsonAsync<StudentsModel>();
            return response;
        }
        public async Task<MainResponseModel> UpdateStudentAsync(Student student, int userid)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Student/{userid}", student);
            var response = await data.Content.ReadFromJsonAsync<MainResponseModel>();
            return response!;
        }

        public async Task<MainResponseModel> AddStudentAfterClass(Student student, int userid, int classid)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/StudentOverall/{userid}/{classid}", student);
            var response = await data.Content.ReadFromJsonAsync<MainResponseModel>();
            return response!;
        }
        public async Task<MainResponseModel> AddNewStudent(Student student, int userid)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/StudentOverall/{userid}", student);
            var response = await data.Content.ReadFromJsonAsync<MainResponseModel>();
            return response!;
        }
        internal static class Converter
        {
            public static readonly Newtonsoft.Json.JsonSerializerSettings Settings = new Newtonsoft.Json.JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    }
}
