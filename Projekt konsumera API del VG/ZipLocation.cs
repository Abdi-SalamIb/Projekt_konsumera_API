using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab_4_del_VG
{
    public class ZipLocation
    {
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; } = string.Empty;

        [JsonPropertyName("place name")]
        public string PlaceName { get; set; } = string.Empty;

        [JsonPropertyName("places")]
        public List<Place> Places { get; set; } = new List<Place>();
    }
}

