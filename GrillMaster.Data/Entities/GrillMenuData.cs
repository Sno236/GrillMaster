using Newtonsoft.Json;
using System.Collections.Generic;

namespace GrillMaster.Data
{
    /// <summary>
    /// JSON equivalent class for main list
    /// </summary>
    public class GrillMenuData
    {
        
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("menu")]
        public string Menu { get; set; }

        [JsonProperty("items")]
        public List<GrillMenuItems> GrillMenuItemsList { get; set; }
    }
}
