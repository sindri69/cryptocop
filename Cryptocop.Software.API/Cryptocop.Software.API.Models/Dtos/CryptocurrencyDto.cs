using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Cryptocop.Software.API.Models.Dtos
{
  //á þessi class að erfa ehv?
  //í large assignment 1 erfa classarnir hypermediamodel
    public class CryptoCurrencyDto
    {
        public string Id { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        [JsonProperty("price_usd")]
        public float PriceInUsd {get; set;}
        [JsonProperty("project_details")]
        public string ProjectDetails {get; set;}

    }
}