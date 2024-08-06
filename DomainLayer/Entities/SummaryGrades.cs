using DomainLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class SummaryGrades
    {
        public List<SummaryRecord> Summary { get; set; }
    }
    public partial class SummaryRecord
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
        public double InitialGrade { get; set; }
        public int QuarterlyGrade { get; set; }
        public int Rank { get; set; }
        public int FinalGrade { get; set; }
        [JsonProperty("quarters")]
        public Dictionary<string, SummarySubjectQuarters> SummarySubject { get; set; }

        
    }
    public class SummarySubjectQuarters
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        [JsonProperty("quarters")]
        public Dictionary<string, SummaryRecordQuarters> Quarters { get; set; }
    }

    public class SummaryRecordQuarters
    {
        [JsonProperty("quarterID")]
        public int QuarterID { get; set; }
        [JsonProperty("grade")]
        public int Sessions { get; set; }
        public int SessionsPresent { get; set; }
        public int Grade { get; set; }
        [JsonProperty("writtenOutput")]
        public int Rank { get; set; }
    }
    
}
