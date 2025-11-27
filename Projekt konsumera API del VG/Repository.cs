using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab_4_del_VG
{

    // Repository class pour GitHub API
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("homepage")]
        public string? Homepage { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime PushedAt { get; set; }
    }

    public class Place
    {
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; } = string.Empty;

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; } = string.Empty;

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; } = string.Empty;

        [JsonPropertyName("post code")]
        public string PostCode { get; set; } = string.Empty;
    }

}

