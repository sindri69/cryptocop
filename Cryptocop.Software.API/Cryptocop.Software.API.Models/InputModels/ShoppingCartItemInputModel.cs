using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class ShoppingCartItemInputModel
    {
        [Required]
        public string ProductIdentifier { get; set; }

        [Required]
        //vantar regex til ad tjekka hvort þetta sé frá og með 0.01 og uppí float maximum value
        public float? Quantity { get; set; }

    }
}