using DomainLayer.Entities;
using DomainLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public partial class RecordModel
    {
        [JsonProperty("student")]
        public Record[] Student { get; set; }
    }

    public partial class Record
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
        public int TotalWrittenScore { get; set; }
        public double AverageWrittenScore { get; set; }
        public int TotalPerformanceScore { get; set; }
        public double AveragePerformanceScore { get; set; }
        public int TotalPeridiocialScore { get; set; }
        public double AveragePeriodicalScore { get; set; }
        public double InitialGrade { get; set; }
        public int QuarterlyGrade { get; set; }
        public int Rank { get; set; }
        public int FinalGrade { get; set; }
        public int Q1 { get; set; }
        public int Q1Rank { get; set; }
        public int Q2 { get; set; }
        public int Q2Rank { get; set; }
        public int Q3 { get; set; }
        public int Q3Rank { get; set; }
        public int Q4 { get; set; }
        public int Q4Rank { get; set; }
        
        public string GradeRemarks { get; set; }

        [JsonProperty("writtenOutput")]
        public Dictionary<string, RecordWrittenOutput>  WrittenOutput { get; set; } 

        [JsonProperty("performanceOutput")]
        public Dictionary<string, RecordPerformanceOutput>  PerformanceOutput { get; set; }

        [JsonProperty("periodicalOutput")]
        public Dictionary<string, RecordPeriodicalOutput>  PeriodicalOutput { get; set; }
        [JsonProperty("quarters")]
        public Dictionary<string, RecordQuarters> Quarters { get; set; }
        [JsonProperty("subject")]
        public Dictionary<string, Subjects> Subject { get; set; }
    }

    public class Subjects
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string SubjectColor { get; set; } = string.Empty;
        [JsonProperty("quarters")]
        public Dictionary<string, RecordQuarters> Quarters { get; set; }
    }
    public class RecordQuarters
    {
        [JsonProperty("quarterID")]
        public int QuarterID { get; set; }
        [JsonProperty("grade")]
        public int Sessions { get; set; }
        public int SessionsPresent { get; set; }
        public int Grade { get; set; }
        [JsonProperty("writtenOutput")]
        public int Rank { get; set; }
        public string GradeRemarks { get; set; } = string.Empty;
        public Dictionary<string, RecordWrittenOutput> WrittenOutput { get; set; }
        [JsonProperty("performanceOutput")]
        public Dictionary<string, RecordPerformanceOutput> PerformanceOutput { get; set; }
        [JsonProperty("periodicalOutput")]
        public Dictionary<string, RecordPeriodicalOutput> PeriodicalOutput { get; set; }
    }
    public partial class RecordWrittenOutput
    {
        [JsonProperty("writtenOutputID")]
        public int WrittenOutputId { get; set; }

        [JsonProperty("writtenOutputName")]
        public string WrittenOutputName { get; set; }

        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty("classID")]
        public int ClassId { get; set; }

        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("quarterID")]
        public int QuarterId { get; set; }

        [JsonProperty("quarterName")]
        public string QuarterName { get; set; }

        [JsonProperty("maxScore")]
        public int MaxScore { get; set; }

        [JsonProperty("writtenData")]
        public RecordWrittenData WrittenData { get; set; }

        [JsonProperty("weightedScore")]
        public float WeightedScore { get; set; }
        public int TotalClassScore { get; set; }
    }

    public partial class RecordWrittenData
    {
        [JsonProperty("writtenDataID")]
        public int WrittenDataId { get; set; }

        [JsonProperty("studentID")]
        public int StudentId { get; set; }

        [JsonProperty("writtenOutputID")]
        public int WrittenOutputId { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
    public partial class RecordPerformanceOutput
    {
        [JsonProperty("performanceOutputID")]
        public int PerformanceOutputId { get; set; }

        [JsonProperty("performanceOutputName")]
        public string PerformanceOutputName { get; set; }

        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty("classID")]
        public int ClassId { get; set; }

        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("quarterID")]
        public int QuarterId { get; set; }

        [JsonProperty("quarterName")]
        public string QuarterName { get; set; }

        [JsonProperty("maxScore")]
        public int MaxScore { get; set; }

        [JsonProperty("performanceData")]
        public RecordPerformanceData PerformanceData { get; set; }

        [JsonProperty("weightedScore")]
        public float WeightedScore { get; set; }
        public int TotalClassScore { get; set; }
    }

    public partial class RecordPerformanceData
    {
        [JsonProperty("performanceDataID")]
        public int PerformanceDataId { get; set; }

        [JsonProperty("performanceOutputID")]
        public int PerformanceOutputId { get; set; }

        [JsonProperty("studentID")]
        public int StudentId { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
    public partial class RecordPeriodicalOutput
    {
        [JsonProperty("periodicalOutputID")]
        public int PeriodicalOutputId { get; set; }

        [JsonProperty("periodicalOutputName")]
        public string PeriodicalOutputName { get; set; }

        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty("classID")]
        public int ClassId { get; set; }

        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("quarterID")]
        public int QuarterId { get; set; }

        [JsonProperty("quarterName")]
        public string QuarterName { get; set; }

        [JsonProperty("maxScore")]
        public int MaxScore { get; set; }

        [JsonProperty("periodicalData")]
        public RecordPeriodicalData PeriodicalData { get; set; }
        [JsonProperty("weightedScore")]
        public float WeightedScore { get; set; }
        public int TotalClassScore { get; set; }
    }
    public partial class RecordPeriodicalData
    {
        [JsonProperty("periodicalDataID")]
        public int PeriodicalDataId { get; set; }

        [JsonProperty("periodicalOutputID")]
        public int PeriodicalOutputId { get; set; }

        [JsonProperty("studentID")]
        public int StudentId { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
    public partial class RecordModel
    {
        public static RecordModel FromJson(string json) => JsonConvert.DeserializeObject<RecordModel>(json, Converter.Converter.Settings);
    }

}
