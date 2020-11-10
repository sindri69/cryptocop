namespace Cryptocop.Software.API.Models.Dtos
{
  //á þessi class að erfa ehv?
  //í large assignment 1 erfa classarnir hypermediamodel
    public class OrderItemDto
    {
        public int Id { get; set; }

        public string ProductIdentifier { get; set; }

        public float? Quantity { get; set; }

        public float? UnitPrice { get; set; }

        public float? TotalPrice {get; set;}

    }
}