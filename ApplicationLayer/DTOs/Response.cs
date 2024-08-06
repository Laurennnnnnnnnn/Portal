using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApplicationLayer.DTOs
{
    
    public class Result<T>
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("errorMessage")]
        public object ErrorMessage { get; set; }

        [System.Text.Json.Serialization.JsonConstructor]
        private Result(bool isSuccess, T data, object errorMessage)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, data, null);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, default, errorMessage);
        }
    }
}
