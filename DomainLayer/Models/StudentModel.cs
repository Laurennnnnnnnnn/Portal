﻿using DomainLayer.Converter;
using Newtonsoft.Json;

namespace DomainLayer.Models
{
    public partial class StudentModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("errorMessage")]
        public object ErrorMessage { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("studentID")]
        public int StudentId { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("middlename")]
        public string Middlename { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("birthdate")]
        public string Birthdate { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("lrn")]
        public string Lrn { get; set; }

        [JsonProperty("creatorID")]
        public int CreatorId { get; set; }
    }

    public partial class StudentModel
    {
        public static StudentModel FromJson(string json) => JsonConvert.DeserializeObject<StudentModel>(json, Converter.Converter.Settings);
    }

    
}
