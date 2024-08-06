using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public class MainResponseModel
    {
        [JsonPropertyName("flag")]
        public bool Flag { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
