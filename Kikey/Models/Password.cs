using Kikey.Helpers;
using Newtonsoft.Json;

namespace Kikey.Models
{
    public class Password
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle")]
        public string SubTitle { get; set; }

        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("password")]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public string ShowText => $"[{Type}] [{Title}] [{SubTitle}] [{Server}] [{User}]";
        public byte[] Hash => SecurityHelper.GetHash($"{Type}{Title}{SubTitle}{Server}{User}{PasswordHash}");
    }
}