namespace Cryptocop.Software.API.Models.Dtos
{
  //á þessi class að erfa ehv?
  //í large assignment 1 erfa classarnir hypermediamodel
    public class PaymentCardDto
    {
        public int Id { get; set; }

        public string CardholderName { get; set; }

        public string CardNumber { get; set; }

        public int Month { get; set; }

        public int Year {get; set;}

    }
}