using DomainLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    
    public partial class SummaryOutputs
    {
        [JsonProperty("writtenOutput")]
        public Dictionary<string, SummaryWrittenOutput> WrittenSumOutput { get; set; }

        [JsonProperty("performanceOutput")]
        public Dictionary<string, SummaryPerformanceOutput> PerformanceSumOutput { get; set; }

        [JsonProperty("periodicalOutput")]
        public Dictionary<string, SummaryPeriodicalOutput> PeriodicalSumOutput { get; set; }
    }
    public partial class SummaryWrittenOutput
    {
        [JsonProperty("writtenOutputID")]
        public int WrittenOutputId { get; set; }

        [JsonProperty("writtenOutputName")]
        public string WrittenOutputName { get; set; }

        [JsonProperty("totalScore")]
        public int totalScore { get; set; }

        [JsonProperty("doSubmit")]
        public int doSubmit { get; set; }
        [JsonProperty("doesntSubmit")]
        public int doesntSubmit { get; set; }
        [JsonProperty("gotZero")]
        public int gotZero { get; set; }
        [JsonProperty("maxScore")]
        public int maxScore { get; set; }
        [JsonProperty("avgScore")]
        public double avgScore { get; set; }
        [JsonProperty("mps")]
        public int mps { get; set; }
        [JsonProperty("deviation")]
        public double deviation { get; set; }

    }

    
    public partial class SummaryPerformanceOutput
    {
        [JsonProperty("performanceOutputID")]
        public int PerformanceOutputId { get; set; }

        [JsonProperty("performanceOutputName")]
        public string PerformanceOutputName { get; set; }

        [JsonProperty("totalScore")]
        public int totalScore { get; set; }
        [JsonProperty("doSubmit")]
        public int doSubmit { get; set; }
        [JsonProperty("doesntSubmit")]
        public int doesntSubmit { get; set; }
        [JsonProperty("gotZero")]
        public int gotZero { get; set; }
        [JsonProperty("maxScore")]
        public int maxScore { get; set; }
        [JsonProperty("avgScore")]
        public double avgScore { get; set; }
        [JsonProperty("mps")]
        public int mps { get; set; }
        [JsonProperty("deviation")]
        public double deviation { get; set; }
    }

    
    public partial class SummaryPeriodicalOutput
    {
        [JsonProperty("periodicalOutputID")]
        public int PeriodicalOutputId { get; set; }

        [JsonProperty("periodicalOutputName")]
        public string PeriodicalOutputName { get; set; }

        [JsonProperty("totalScore")]
        public int totalScore { get; set; }
        [JsonProperty("doSubmit")]
        public int doSubmit { get; set; }
        [JsonProperty("doesntSubmit")]
        public int doesntSubmit { get; set; }
        [JsonProperty("gotZero")]
        public int gotZero { get; set; }
        [JsonProperty("maxScore")]
        public int maxScore { get; set; }
        [JsonProperty("avgScore")]
        public double avgScore { get; set; }
        [JsonProperty("mps")]
        public int mps { get; set; }
        [JsonProperty("deviation")]
        public double deviation { get; set; }

    }
    public partial class SummaryOutputs
    {
        public static SummaryOutputs FromJson(string json) => JsonConvert.DeserializeObject<SummaryOutputs>(json, Converter.Converter.Settings);
    }
}
