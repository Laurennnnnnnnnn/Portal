using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public partial class AttendanceDataModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("data")]
        public AttendData Data { get; set; }

        [JsonProperty("errorMessage")]
        public object ErrorMessage { get; set; }
    }

    public partial class AttendData
    {
        [JsonProperty("attendanceID")]
        public int AttendanceId { get; set; }

        [JsonProperty("studentID")]
        public int StudentId { get; set; }

        [JsonProperty("classID")]
        public int ClassId { get; set; }

        [JsonProperty("quarterID")]
        public int QuarterId { get; set; }

        [JsonProperty("attendanceDate")]
        public string AttendanceDate { get; set; }

        [JsonProperty("statusID")]
        public int StatusId { get; set; }

        [JsonProperty("statusName")]
        public string StatusName { get; set; }
    }
}
