using Newtonsoft.Json;

namespace GrillMaster.Data
{
    /// <summary>
    /// JSON equivalent class for sub  within main list
    /// </summary>
    public class GrillMenuItems
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Length")]
        public int Length { get; set; }
        [JsonProperty("Width")]
        public int Width { get; set; }
        [JsonProperty("Duration")]
        public string Duration { get; set; }
        [JsonProperty("Quantity")]
        public int Quantity { get; set; }
    }
}
