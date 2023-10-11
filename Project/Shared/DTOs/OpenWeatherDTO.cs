using Newtonsoft.Json;
using Project.Shared.Domain;
using System.Text.Json.Serialization;

namespace Project.Shared.DTOs
{

    public class OpenWeatherModelDTO : Entity
    {
        public OpenWeatherModelDTO()
        {

        }
        public DateTime datehour { get; set; }
        //SE PODRIA HABER DIVIDO COUNTRY EN OTRA CLASE PARA QUE SEA UNA CLAVE FORANEA
        public string country { get; set; }
        public string city { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string temp { get; set; }
        public string feels_like { get; set; }
    }

    #region Service OpenWeather DTO

    public class Clouds
    {
        [JsonProperty("all")]
        [JsonPropertyName("all")]
        public int all { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lon")]
        [JsonPropertyName("lon")]
        public double lon { get; set; }

        [JsonProperty("lat")]
        [JsonPropertyName("lat")]
        public double lat { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        [JsonPropertyName("temp")]
        public double temp { get; set; }

        [JsonProperty("feels_like")]
        [JsonPropertyName("feels_like")]
        public double feels_like { get; set; }

        [JsonProperty("temp_min")]
        [JsonPropertyName("temp_min")]
        public double temp_min { get; set; }

        [JsonProperty("temp_max")]
        [JsonPropertyName("temp_max")]
        public double temp_max { get; set; }

        [JsonProperty("pressure")]
        [JsonPropertyName("pressure")]
        public int pressure { get; set; }

        [JsonProperty("humidity")]
        [JsonPropertyName("humidity")]
        public int humidity { get; set; }

        [JsonProperty("sea_level")]
        [JsonPropertyName("sea_level")]
        public int sea_level { get; set; }

        [JsonProperty("grnd_level")]
        [JsonPropertyName("grnd_level")]
        public int grnd_level { get; set; }
    }

    public class Rain
    {
        [JsonProperty("1h")]
        [JsonPropertyName("1h")]
        public double _1h { get; set; }
    }

    public class OpenWeather
    {
        [JsonProperty("coord")]
        [JsonPropertyName("coord")]
        public Coord coord { get; set; }

        [JsonProperty("weather")]
        [JsonPropertyName("weather")]
        public List<Weather> weather { get; set; }

        [JsonProperty("base")]
        [JsonPropertyName("base")]
        public string @base { get; set; }

        [JsonProperty("main")]
        [JsonPropertyName("main")]
        public Main main { get; set; }

        [JsonProperty("visibility")]
        [JsonPropertyName("visibility")]
        public int visibility { get; set; }

        [JsonProperty("wind")]
        [JsonPropertyName("wind")]
        public Wind wind { get; set; }

        [JsonProperty("rain")]
        [JsonPropertyName("rain")]
        public Rain rain { get; set; }

        [JsonProperty("clouds")]
        [JsonPropertyName("clouds")]
        public Clouds clouds { get; set; }

        [JsonProperty("dt")]
        [JsonPropertyName("dt")]
        public int dt { get; set; }

        [JsonProperty("sys")]
        [JsonPropertyName("sys")]
        public Sys sys { get; set; }

        [JsonProperty("timezone")]
        [JsonPropertyName("timezone")]
        public int timezone { get; set; }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonProperty("cod")]
        [JsonPropertyName("cod")]
        public int cod { get; set; }
    }

    public class Sys
    {
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public int type { get; set; }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonProperty("country")]
        [JsonPropertyName("country")]
        public string country { get; set; }

        [JsonProperty("sunrise")]
        [JsonPropertyName("sunrise")]
        public int sunrise { get; set; }

        [JsonProperty("sunset")]
        [JsonPropertyName("sunset")]
        public int sunset { get; set; }
    }

    public class Weather
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonProperty("main")]
        [JsonPropertyName("main")]
        public string main { get; set; }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonProperty("icon")]
        [JsonPropertyName("icon")]
        public string icon { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        [JsonPropertyName("speed")]
        public double speed { get; set; }

        [JsonProperty("deg")]
        [JsonPropertyName("deg")]
        public int deg { get; set; }

        [JsonProperty("gust")]
        [JsonPropertyName("gust")]
        public double gust { get; set; }
    }
    #endregion

}
