using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class PaymentCardInputModel
    {
        [Required]
        [MinLength(3)]
        public string CardholderName { get; set; }

        [Required]
        //vantar regex til að validatea creditcardnumber
        public string CardNumber { get; set; }

        //vantar regex til að tjekka hvort þetta sé á milli 1-12
        public int Month { get; set; }
        
        //vantar range til að tjékka hvort þetta sé á milli 0-99
        public int Year { get; set; }
    }
}