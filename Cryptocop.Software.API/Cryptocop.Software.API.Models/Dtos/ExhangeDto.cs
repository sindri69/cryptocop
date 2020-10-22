
namespace Cryptocop.Software.API.Models.Dtos
{
  //á þessi class að erfa ehv?
  //í large assignment 1 erfa classarnir hypermediamodel
    public class ExchangeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string AssetSymbol { get; set; }

        public float? PriceInUsd {get; set;}

        public DateTime? LastTrade {get; set;}

    }
}