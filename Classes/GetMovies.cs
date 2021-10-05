using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dio.Series.Classes
{
    public partial class GetMovies
    {
        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }
    }
    public partial class Item
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("rank")]
        public string Rank { get; set; }
        [JsonPropertyName("rankUpDown")]
        public string RankUpDown { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("fullTitle")]
        public string FullTitle { get; set; }
        [JsonPropertyName("year")]
        public string Year { get; set; }
        [JsonPropertyName("image")]
        public Uri Image { get; set; }
        [JsonPropertyName("crew")]
        public string Crew { get; set; }
        [JsonPropertyName("imDbRating")]
        public string ImDbRating { get; set; }
        [JsonPropertyName("imDbRatingCount")]
        public string ImDbRatingCount { get; set; }
    }
}
