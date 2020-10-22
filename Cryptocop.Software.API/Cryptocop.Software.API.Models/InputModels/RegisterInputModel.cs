using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class RegisterInputModel
    {
        [Required]
        //vantar regex til að validatea email
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        
        [Required]
        [MinLength(8)]
        //regex til ad tjekka hvort þetta se sami strengur og pw
        public string PasswordConfirmation { get; set; }
    }
}