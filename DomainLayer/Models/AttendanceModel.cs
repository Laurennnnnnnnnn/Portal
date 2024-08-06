using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public partial class AttendanceModel
    {
        [JsonProperty("attendance")]
        public Attendance[] Attendance { get; set; }
    }

    public partial class Attendance
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

        [JsonProperty("attendanceOutput")]
        public Dictionary<string, AttendanceOutput> AttendanceOutput { get; set; }
    }

    public partial class AttendanceOutput
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

    public partial class AttendanceModel
    {
        public static AttendanceModel FromJson(string json) => JsonConvert.DeserializeObject<AttendanceModel>(json, Converter.Converter.Settings);
    }

}
