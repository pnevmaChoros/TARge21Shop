using System.Text.Json.Serialization;

namespace TARge21Shop.Core.Dto
{
    public class HeadlineDto
    {
        [JsonPropertyName("EffectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("EffectiveEpochDate")]
        public int EffectiveEpochDate { get; set; }

        [JsonPropertyName("Serverity")]
        public int Severity { get; set; }

        [JsonPropertyName("Text")]
        public string Text { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }
        public DateTime EndDate { get; set; }

        public int EndEpochDate { get; set; }

        [JsonPropertyName("MobileLink")]
        public string MobileLink { get; set; }

        [JsonPropertyName("Link")]
        public string Link { get; set; }

        public Temperature Temperature { get; set; }

        public Day Day { get; set; }

        public Night Night { get; set; }

        public List<string> Sources { get; set; }
    }
}
