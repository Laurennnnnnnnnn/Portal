using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public partial class WrittenOutputModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("errorMessage")]
        public object ErrorMessage { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("writtenOutputID")]
        public long WrittenOutputId { get; set; }

        [JsonProperty("writtenOutputName")]
        public string WrittenOutputName { get; set; }

        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty("classID")]
        public long ClassId { get; set; }

        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("quarterID")]
        public long QuarterId { get; set; }

        [JsonProperty("quarterName")]
        public string QuarterName { get; set; }

        [JsonProperty("maxScore")]
        public long MaxScore { get; set; }

        [JsonProperty("writtenData")]
        public object WrittenData { get; set; }
    }
    public partial class WrittenOutputModel
    {
        public static WrittenOutputModel FromJson(string json) => JsonConvert.DeserializeObject<WrittenOutputModel>(json, Converter.Converter.Settings);
    }
}
