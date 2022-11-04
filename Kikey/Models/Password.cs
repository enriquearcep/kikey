using Kikey.Helpers;
using Newtonsoft.Json;

namespace Kikey.Models
{
    public class Password
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Server { get; set; }
        public string User { get; set; }
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public string ShowText => $"[{Type}] [{Title}] [{Server}] [{User}]";
        public byte[] Hash => SecurityHelper.GetHash($"{Type}{Title}{SubTitle}{Server}{User}{PasswordHash}");
    }
}