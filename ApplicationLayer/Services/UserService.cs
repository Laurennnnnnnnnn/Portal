using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using DomainLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddUser(User userdata)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/User/AddUser", userdata);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteUser(int userdataid, int userid)
        {
            var data = await _httpClient.DeleteAsync($"api/User/DeleteUser/{userdataid}/{userid}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<Result<List<User>>> GetAllUnverifiedUser()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<User>>>($"api/User/GetUnverified");
            return data;
        }

        public async Task<Result<List<User>>> GetAllVerifiedUser()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<User>>>($"api/User/GetVerified");
            return data;
        }

        public async Task<Result<List<Category>>> GetCategory()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<Category>>>($"api/User/GetCategory");
            return data;
        }

        public async Task<Result<List<UserType>>> GetUserType()
        {
            var data = await _httpClient.GetFromJsonAsync<Result<List<UserType>>>($"api/User/GetUserType");
            return data;
        }

        public async Task<ServiceResponse> UpdateUser(User userdata)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/User/UpdateUser", userdata);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<Result<User>> UserLogin(string username, string password)
        {
               
            try
            {
                var result = await _httpClient.GetFromJsonAsync<Result<User>>($"api/User/{username}/{password}");
                return result;
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (NotSupportedException ex)
            {
                // Handle content type errors
                Console.WriteLine($"The content type is not supported: {ex.Message}");
                throw;
            }
            //catch (JsonException ex)
            //{
            //    // Handle JSON serialization errors
            //    Console.WriteLine($"JSON error: {ex.Message}");
            //    throw;
            //}

        }

        public async Task<ServiceResponse> VerifyUser(int userdataid, int userid)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/User/VerifyUser/{userdataid}/{userid}", new StringContent(""));
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> UnverifyUser(int userdataid, int userid)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/User/UnverifyUser/{userdataid}/{userid}", new StringContent(""));
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }


        //public async Task<Payroll> PostPayroll()
        //{


        //    var postdata = new Data()
        //    {
        //        access_number = "123457",
        //        date = "01/04/2024",
        //        time = "8:00",
        //        access_type ="1",
        //        device_number = "0",
        //        transaction_type = "1"
        //    };
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "DvJFx75T5BcbIR0HzriPsAWJkIiEzKWftisA8EF");
        //    //_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer DvJFx75T5BcbIR0HzriPsAWJkIiEzKWftisA8EFm");
        //    _httpClient.DefaultRequestHeaders.Add("ClientID", "biometricsapitest123456");

        //    var data = await _httpClient.PostAsJsonAsync("https://demo.filipayroll.com/api/tm-biometrics-logs", postdata);
        //    var response = await data.Content.ReadFromJsonAsync<Payroll>();
        //    return response!;
        //}

        //public partial class Payroll
        //{
        //    [JsonProperty("num_of_records")]
        //    public long NumOfRecords { get; set; }

        //    [JsonProperty("status")]
        //    public string Status { get; set; }

        //    [JsonProperty("message")]
        //    public string Message { get; set; }
        //    [JsonProperty("error")]
        //    public string Error { get; set; }
        //}
        //public class Data
        //{

        //    public string access_number { get; set; } = string.Empty;
        //    public string date { get; set; } = string.Empty;
        //    public string time { get; set; } = string.Empty;
        //    public string device_number { get; set; } = string.Empty;
        //    public string transaction_type { get; set; } = string.Empty;
        //    public string access_type { get; set; } = string.Empty;
            
        //}
    }
}
